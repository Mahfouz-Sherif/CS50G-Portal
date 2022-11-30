--[[
    GD50
    Match-3 Remake

    -- Tile Class --

    Author: Colton Ogden
    cogden@cs50.harvard.edu

    The individual tiles that make up our game board. Each Tile can have a
    color and a variety, with the varietes adding extra points to the matches.
]]

Tile = Class{}

function Tile:init(x, y, color, variety)
    
    -- board positions
    self.gridX = x
    self.gridY = y

    -- coordinate positions
    self.x = (self.gridX - 1) * 32
    self.y = (self.gridY - 1) * 32

    -- tile appearance/points
    self.color = color
    self.variety = variety


if math.random()>=0.96 then
    self.shiny = true
end

  self.shineAnimation=false
Timer.every(0.6, function()
    self.shineAnimation = not self.shineAnimation
end)
end

function Tile:render(x, y)
    
    -- draw shadow
    love.graphics.setColor(34, 32, 52, 255)
    love.graphics.draw(gTextures['main'], gFrames['tiles'][self.color][self.variety],
        self.x + x + 2, self.y + y + 2)

    -- draw tile itself
    love.graphics.setColor(255, 255, 255, 255)
    love.graphics.draw(gTextures['main'], gFrames['tiles'][self.color][self.variety],
        self.x + x, self.y + y)

        if self.shiny then
            love.graphics.setLineWidth(3)
            if self.shineAnimation then
                love.graphics.setColor(50/255, 30/255, 255/255, 1)
            else
                love.graphics.setColor(50/255, 30/255, 150/255, 1)
            end
           love.graphics.rectangle('line', self.x + (VIRTUAL_WIDTH - 272), self.y + 16, 32, 32, 4)
        end
        
end