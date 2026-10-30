# C# - Delegates & Events

This project explores delegates and events in C#. It covers the creation of custom delegates, multicast delegates, event handling using `EventHandler<T>`, `EventArgs`, and dynamic event subscription.

## Tasks

- **0. Universal health**: Create a `Player` class with `name`, `maxHp`, and `hp` fields, constructor validation, and `PrintHealth()` method.
- **1. Damage delegation**: Create a `CalculateHealth` delegate and implement `TakeDamage` and `HealDamage` methods.
- **2. Validation**: Add `ValidateHP` method to update health and clamp values between 0 and `maxHp`.
- **3. Modified behavior**: Create a `Modifier` enum and `CalculateModifier` delegate, and implement `ApplyModifier` in `Player`.
- **4. Check yourself**: Create `CurrentHPArgs` and an `HPCheck` event that updates and prints the player's status based on health percentage.
- **5. Eventful**: Implement `HPValueWarning` and `OnCheckStatus` method to dynamically subscribe warning messages when health is low or zero.
