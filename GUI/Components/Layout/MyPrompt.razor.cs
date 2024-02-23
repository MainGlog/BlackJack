using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Timers;
using Timer = System.Timers.Timer;
//Whenever referencing Timers in this namespace, it will refer to System.Timers, since Threading.Timers exists.
namespace GUI.Components.Layout
{
    public partial class MyPrompt : ComponentBase
    {
        private String Time { get; set; } = "Not set yet"; 
        //Initialized to avoid null errors
        //You could set the time up top, but it would make debugging easier
        private Timer? timer;
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Time = DateTime.Now.ToString("h:mm:ss tt");

            timer = new Timer(1000);
            timer.Elapsed += RefreshTime;
            timer.AutoReset = true;
            timer.Enabled = true;

            //Timer starts a new thread
            //The renderer will not refresh itself unless another event gets called

        }

        private void RefreshTime(Object? source, ElapsedEventArgs e) //source is who called timer, ElapsedEventArgs is anything that you want to pass in
        {
            Time = DateTime.Now.ToString("h:mm:ss tt");
            InvokeAsync(StateHasChanged); //InvokeAsync because diff thread, StateHasChanged to refresh screen
        }
    }
}
