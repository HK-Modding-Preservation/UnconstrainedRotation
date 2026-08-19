using Modding;
using UnityEngine;

namespace UnconstrainedRotation {
    public class UnconstrainedRotation: Mod, ITogglableMod {
        new public string GetName() => "UnconstrainedRotation";
        public override string GetVersion() => "1.1.0.0";

        public override void Initialize() {
            On.HeroController.Update10 += heroUpdate;
        }

        public void Unload() {
            On.HeroController.Update10 -= heroUpdate;
            try {
                Rigidbody2D rb = HeroController.instance.gameObject.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.transform.rotation = Quaternion.identity;
            }
            catch(System.Exception) { }
        }

        private void heroUpdate(On.HeroController.orig_Update10 orig, HeroController self) {
            orig(self);
            Rigidbody2D rb = self.gameObject.GetComponent<Rigidbody2D>();
            RigidbodyConstraints2D constraints = rb.constraints;
            rb.constraints = constraints & (RigidbodyConstraints2D.FreezePosition);

        }
    }
}