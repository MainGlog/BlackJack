using Microsoft.AspNetCore.Components;

namespace GUI.Components.Pages
//Code behind file, better to write all C# code in one location
{
    public partial class Counter : ComponentBase //All code behind files need to inherit ComponentBase
        //Partial classes - there can be many instances of the same class if they are marked as partial
    {
        private int currentCount = 0;
        //Constructor will not get called in blazor
        //To initialize, you can override OnInitialized method
        protected override void OnInitialized()
        {
            //Called before page is rendered
            base.OnInitialized();
        }
        /*protected override void OnAfterRender(bool firstRender)
        {
            //Called after page is rendered
            base.OnAfterRender(firstRender);
        }*/
        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
