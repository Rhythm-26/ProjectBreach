Class = require 'lib/class'
push = require 'lib/push'

require 'src/constants'
require 'src/utils'
require 'src/StateMachine'

require 'src/states/BaseState'
require 'src/states/StateStack'
require 'src/states/BattleState'

gTextures = {
    ['tiles'] = love.graphics.newImage('assets/tilesheet.png')
}

gFrames = {
    ['tiles'] = GenerateQuads(gTextures['tiles'], 32, 32)
}