using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_WASM
{
    public class AppStateContainer
    {
        public int ValueState { get; set; }
        public event Action OnStateChanged;
        /// <summary>
        /// The method will be invoked by components to update the state</summary>
        /// <param name="v"></param>
        public void UpdateState(int v) {
            ValueState = v;

            // Raise the Event for Notification
            NotifyStateChanged();
        }


        private void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}
