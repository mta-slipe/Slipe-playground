
function prePatches()
    
    bit = {
        bnot = bitNot,
        band = bitAnd,
        bor = bitOr,
        bxor = bitXor,
        lshift = bitLShift,
        rshift = bitRShift
    }

    function require() end

    setmetatable(_G, {
        __newindex = function(...) 
            duringPatches(...)
        end
    })
end

local patches = {}

function duringPatches(t, key, value)

        
    if (not patches.systemIs and key == "System") then
        if (not getmetatable(value)) then
            setmetatable(value, {})
        end

        getmetatable(value).__newindex = function(systemT, systemKey, systemValue)

            if systemKey == "is" then
                local function localIs(obj, T)
                    return type(obj) == "userdata" or systemValue(obj, T)
                end

                rawset(systemT, systemKey, localIs)
                patches.systemIs = true
                return
            end

            rawset(systemT, systemKey, systemValue)
        end

        patches.system = true
    end

    rawset(t, key, value)
end

function postPatches()
    
    setmetatable(_G, nil)
end

prePatches()
