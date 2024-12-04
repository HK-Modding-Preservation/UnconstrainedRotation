using Modding;
using UnityEngine;

namespace UnconstrainedRotation {
    public class UnconstrainedRotation: Mod {
        new public string GetName() => "UnconstrainedRotation";
        public override string GetVersion() => "1.0.0.0";

        public override void Initialize() {
            On.HeroController.Start += heroStart;
        }

        private void heroStart(On.HeroController.orig_Start orig, HeroController self) {
            orig(self);
            self.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}