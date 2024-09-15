using UnityEngine;

namespace Padrox.Acelab.Timers
{
    /// <summary>
    /// Timer that counts up from zero to infinity. Great for measuring durations.
    /// | Credits: <see href="https://www.youtube.com/@git-amend">git-amend</see>
    /// </summary>
    public class StopwatchTimer : Timer {
        public StopwatchTimer() : base(0) { }

        public override void Tick() {
            if (IsRunning) {
                CurrentTime += Time.deltaTime;
            }
        }

        public override bool IsFinished => false;
    }
}
