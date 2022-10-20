--[[

    Author: Mahfouz Sherif
    
]]
Powerup = Class{}

function Powerup:init(x, y, type) -- x and y are the starting point of the powerup
    self.x = x
    self.y = y
    self.type = type
    self.fall = false            -- fall is whether the powerup is going to fall or not
end

function Powerup:update(dt)
    if  self.y > 0 then
        self.fall = true
    end

    if self.fall == true then
    self.y = self.y + 0.7
    end
end

function Powerup:render()  
    if self.fall == true then   
        love.graphics.draw(gTextures['main'], -- pick the atlas
        gFrames['powerups'][self.type], self.x,self.y)
                                              
    end

end

function Powerup:collide(target)
    if self.y + 16 < target.y 
    or self.y > target.y + target.height 
    or self.x + 16 < target.x or 
    self.x > target.x + target.width then
        return false
    else
        return true
    end
end
