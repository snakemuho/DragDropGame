# Drag Drop Game

A prototype of a game where you can pick up items and drop them around the level.

![image](https://github.com/user-attachments/assets/08d10133-dd2c-46fd-8adf-624b1fdefb22)

---

## 🎮 **Gameplay Overview**

In this prototype:
- There is a level you can scroll left and right.
- The items on the level can be picked up and dropped on the floor or furniture.

![Game Screenshot](https://github.com/user-attachments/assets/42bbfb44-0147-4954-95db-cf4058a3b268)

---

## 🔧 **Features**

### 1. **Camera scrolling**
- Camera can be scrolled horizontally.
- Boundaries and scrolling speed can be changed in editor, in the `Camera Scroller` script attached to `Main Camera` gameobject.

![Camera Setup](https://github.com/user-attachments/assets/46839141-e456-479e-8775-419c73ca0bf4)

### 2. **Item dragging**
- The item can be picked up and dropped around the level.
- The item either falls down, snaps to the closest furniture or to the floor.
- The `Item` script serves as the central script that determines what each component of the item should do.
- `Drag component` defines the item's drag behavior, and tracks if the item is being dragged.
- `Gravity component` makes the item fall or stop falling, and tracks the item's velocity.
- `Collision tracker` tracks if the item is inside the furniture's or floor's colliders, and events that should happen when the item enters these colliders.
- `Snap component` makes the item either snap to the closest furniture, or to the floor.
- `Audio component` defines the audio that should play when the item is picked up.

![Item](https://github.com/user-attachments/assets/6c3e747d-99be-4d4d-b524-e9e5b4462ef0)


### 3. **Background**
- Where the item will snap is determined by colliders placed around the level.
- There is a single collider for the floor that has a `Floor` tag
- For each furniture object there is a collider with a `Furniture` tag
  - The item snaps to the closest point on the `x` axis of the collider, and to the lowest border of the collider on `y` axis

![Background](https://github.com/user-attachments/assets/59179e6f-5aa3-4861-9f4c-4d6ca9daea70)
![Hitbox prefabs](https://github.com/user-attachments/assets/3c540756-a7e3-4ed9-9f4c-ccf0804be0ac)

---
