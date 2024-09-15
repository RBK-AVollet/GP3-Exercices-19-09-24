using UnityEngine;

namespace Rubika {
    public static class Vector2Extensions {
        public static Vector2 With(this Vector2 v, float? x = null, float? y = null) {
            return new Vector2(x ?? v.x, y ?? v.y);
        }
    }
}