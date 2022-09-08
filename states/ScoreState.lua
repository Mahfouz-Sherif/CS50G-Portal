--[[
    ScoreState Class
    Author: Colton Ogden
    cogden@cs50.harvard.edu

    A simple state used to display the player's score before they
    transition back into the play state. Transitioned to from the
    PlayState when they collide with a Pipe.
]]

ScoreState = Class{__includes = BaseState}

--[[
    When we enter the score state, we expect to receive the score
    from the play state so we know what to render to the State.
]]
function ScoreState:init()
    self.bronze = love.graphics.newImage('bronze-medal.png')
    self.silver = love.graphics.newImage('silver-medal.png')
    self.gold = love.graphics.newImage('gold-medal.png')
end
function ScoreState:enter(params)
    self.score = params.score
end

function ScoreState:update(dt)
    -- go back to play if enter is pressed
    if love.keyboard.wasPressed('enter') or love.keyboard.wasPressed('return') then
        gStateMachine:change('countdown')
    end
end

function ScoreState:render()
    love.graphics.setFont(flappyFont)
    -- render the appropriate model according to the score

    if self.score>=10 then
        love.graphics.printf('Great Job! Gold Medal earned', 0, 64, VIRTUAL_WIDTH, 'center')
        love.graphics.draw(self.gold, VIRTUAL_WIDTH-150, VIRTUAL_HEIGHT/2-60, 0, 0.05, 0.05)
    elseif self.score>=7 then
        love.graphics.printf('Good Job! Silver Medal earned', 0, 64, VIRTUAL_WIDTH, 'center') 
        love.graphics.draw(self.silver, VIRTUAL_WIDTH-150, VIRTUAL_HEIGHT/2-60, 0, 0.05, 0.05)
    elseif self.score>=4 then
        love.graphics.printf('Keep Going! Bronze Medal earned', 0, 64, VIRTUAL_WIDTH, 'center') 

        love.graphics.draw(self.bronze, VIRTUAL_WIDTH-150, VIRTUAL_HEIGHT/2-60, 0, 0.05, 0.05)
    else   
        love.graphics.printf('Oof! You lost!', 0, 64, VIRTUAL_WIDTH, 'center')
    end
        -- simply render the score to the middle of the screen
    love.graphics.setFont(mediumFont)
    love.graphics.printf('Score: ' .. tostring(self.score), 0, 100, VIRTUAL_WIDTH, 'center')

    love.graphics.printf('Press Enter to Play Again!', 0, 160, VIRTUAL_WIDTH, 'center')
end