require 'src/dependencies'

function love.load()
-- Set Window Title
    love.window.setTitle('Project Breach')
    
-- Set Graphic Draw mode for pixel art style
    love.graphics.setDefaultFilter('nearest', 'nearest')

-- Seed for Random Generation
    math.randomseed(os.time())

-- Sets up screen for rendering
    push:setupScreen(VIRTUAL_WIDTH, VIRTUAL_HEIGHT, WINDOW_WIDTH, WINDOW_HEIGHT, {
        fullscreen = false,
        vsync = true,
        resizable = true
    })

    --love._openConsole()

-- Set up the State Stack on load
    gStateStack = StateStack()
    gStateStack:push(BattleState())

--Global table for keyboard input    
    love.keyboard.keysPressed = {}
end

function love.keypressed(key)
    if key == 'escape' then
        love.event.quit()
    end

    love.keyboard.keysPressed[key] = true
end

function love.keyboard.wasPressed(key)
    return love.keyboard.keysPressed[key]
end

function love.update(dt)
    
    gStateStack:update(dt)

end

function love.draw()
    push:start()

    gStateStack:render()
    
    push:finish()
end