# The Line Zen Clone: Unity Project Breakdown

Part of my Futurae teaching intervention. Second student project: Unity recreation of The Line Zen highlighting core programming concepts and system design.

## **Core Features**

**🔄 Game State Management**

- UnityEvent-driven state transitions (Menu/InGame/Pause/GameOver)
- Singleton implementation with scene persistence

**🎮 Input & Movement**

- Horizontal-only control via Rigidbody.position manipulation
- Input smoothing with axis clamping and dead zones
- Continuous collision detection + interpolation for fluid motion

**🌀 Procedural Generation**

- Runtime obstacle spawning with prefab variations
- Object pooling for segments and physic objects

**💥 Collision System**

- Layer-based interactions with physics material tuning
- Tag-driven responses (e.g., "Obstacle" triggers game over)

## **Key Programming Takeaways**

**⚡ Event-Driven Design**

- Decoupled systems via Event subscriptions
- State changes broadcast across components without direct references

**🔧 Physics Optimization**

- FixedUpdate for movement vs Update for input polling
- Rigidbody interpolation + Continuous Dynamic collision mode

**📦 System Architecture**

- Singleton & Observer patterns
- SOLID principles

**💾 Data Flow**

- JSON serialization wrapped with **`PlayerPref`**
- Prefab variant system for obstacle modularity

[Released to itch.io](https://lacrearthur.itch.io/the-line-zen)
