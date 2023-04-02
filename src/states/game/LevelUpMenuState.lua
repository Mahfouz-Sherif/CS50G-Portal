--[[
    GD50
    Pokemon

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

LevelUpMenuState = Class{__includes = BaseState}

function LevelUpMenuState:init(battleState, statsLevelUp)
    self.battleState = battleState

    local pokemon = battleState.player.party.pokemon[1]

    self.levelUpMenu = Menu {
        x = VIRTUAL_WIDTH/2 - 180/2,
        y = VIRTUAL_HEIGHT/2 - 92,
        width = 180,
        height = 180/2 + 20,
        cursorFlag = false, -- do not display cursor
        items = {
            {
                text = string.format("HP: %d + %d = %d", pokemon.HP-statsLevelUp[1], statsLevelUp[1], pokemon.HP),
                onSelect = function()
                     gStateStack:pop()
                    -- gStateStack:push(TakeTurnState(self.battleState))
                end
            },
            {
                text = string.format("Attack: %d + %d = %d", pokemon.attack-statsLevelUp[2], statsLevelUp[2],pokemon.attack),
                onSelect = function()
                    --gSounds['run']:play()
                    
                    -- pop battle menu
                     gStateStack:pop()
                end
            },
            {
                text = string.format("Defense: %d + %d = %d", pokemon.defense-statsLevelUp[3], statsLevelUp[3], pokemon.defense),
                onSelect = function()
                    --gSounds['run']:play()
                    
                    -- pop battle menu
                     gStateStack:pop()
                end
            },
            {
                text = string.format("Speed: %d + %d = %d", pokemon.speed-statsLevelUp[4], statsLevelUp[4], pokemon.speed),
                onSelect = function()
                    --gSounds['run']:play()
                    
                    -- pop battle menu
                     gStateStack:pop()
                end
            }
        }
    }
end

function LevelUpMenuState:update(dt)
    self.levelUpMenu:update(dt)
end

function LevelUpMenuState:render()
    self.levelUpMenu:render()
end