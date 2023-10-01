using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text;


namespace LiveSplit.UI.Components
{

    

    //Start of Component Class
    public class SplitendoPowerComponent : IComponent
    {
        

        // This internal component does the actual heavy lifting. Whenever we want to do something
        // like display text, we will call the appropriate function on the internal component.
        protected InfoTextComponent InternalComponent { get; set; }
        // This is how we will access all the settings that the user has set.
        public SplitendoPowerSettings Settings { get; set; }
        // This object contains all of the current information about the splits, the timer, etc.
        protected LiveSplitState CurrentState { get; set; }

        public string ComponentName => "Splitendo Power";

        public float HorizontalWidth => InternalComponent.HorizontalWidth;
        public float MinimumWidth => InternalComponent.MinimumWidth;
        public float VerticalHeight => InternalComponent.VerticalHeight;
        public float MinimumHeight => InternalComponent.MinimumHeight;

        public float PaddingTop => InternalComponent.PaddingTop;
        public float PaddingLeft => InternalComponent.PaddingLeft;
        public float PaddingBottom => InternalComponent.PaddingBottom;
        public float PaddingRight => InternalComponent.PaddingRight;

        // I'm going to be honest, I don't know what this is for, but I know we don't need it.
        public IDictionary<string, Action> ContextMenuControls => null;


        

        // This function is called when LiveSplit creates your component. This happens when the
        // component is added to the layout, or when LiveSplit opens a layout with this component
        // already added.

        //>>>>>>>>>>>>>>>>>>>>>> Constructor at the ResetChanceComponent of the tutorial<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //>>>>>>>>>>>>>>>>>>>>>> Constructor at the ResetChanceComponent of the tutorial<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //>>>>>>>>>>>>>>>>>>>>>> Constructor at the ResetChanceComponent of the tutorial<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


        public SplitendoPowerComponent(LiveSplitState state)
        {

            Settings = new SplitendoPowerSettings();
            InternalComponent = new InfoTextComponent("Splitendo Power", "On!");

            state.OnStart += state_OnStart;
            state.OnSplit += state_OnSplitChange;
            state.OnSkipSplit += state_OnSplitChange;
            state.OnUndoSplit += state_OnSplitChange;
            state.OnReset += state_OnReset;
            CurrentState = state;

        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawHorizontal(g, state, height, clipRegion);
        }

        // We will be adding the ability to display the component across two rows in our settings menu.
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            InternalComponent.DisplayTwoRows = Settings.Display2Rows;

            InternalComponent.NameLabel.HasShadow
                = InternalComponent.ValueLabel.HasShadow
                = state.LayoutSettings.DropShadows;

            InternalComponent.NameLabel.ForeColor = state.LayoutSettings.TextColor;
            InternalComponent.ValueLabel.ForeColor = state.LayoutSettings.TextColor;

            InternalComponent.DrawVertical(g, state, width, clipRegion);
        }

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            Settings.SetSettings(settings);
        }


        //Lightswitch variable; set these to off, the SplitStatus functions at the bototm turn them on, the Update function turns them off and fires code
        string updateSplit = "no";

        // This is the function where we decide what needs to be displayed at this moment in time,
        // and tell the internal component to display it. This function is called hundreds to
        // thousands of times per second.
        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {

            //You hit the split button
            if (updateSplit != "no")
            {
                //close the loop, tell the web app to update
                updateSplit = "no";
                File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitChange", "1");


                //If you just reset, go back to intro screen.
                if (updateSplit == "reset") {

                    File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitName", "___INTRO___");
                    File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitIndex", "-1");

                }

                //You started a run or went to the next split
                else
                {

                    //You're in the middle of a run
                    if (state.CurrentSplitIndex < state.Run.Count) {

                        File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitName", state.Run[state.CurrentSplitIndex].Name);
                        File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitIndex", state.CurrentSplitIndex.ToString());

                    }


                    //You just hit  your last speed; you didn't "finish" the run and the final time is still on the screen.
                    //Go back to start to prevent any kind of Indices being OUt of Bounds
                    else {

                        File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitName", "___INTRO___");
                        File.WriteAllText(Settings.SPDir + "\\data\\vars\\splitIndex", "-1");

                    }
                    
                }

                
            }

                
                
        }

        // This function is called when the component is removed from the layout, or when LiveSplit
        // closes a layout with this component in it.
        public void Dispose()
        {

            CurrentState.OnStart -= state_OnStart;
            CurrentState.OnSplit -= state_OnSplitChange;
            CurrentState.OnSkipSplit -= state_OnSplitChange;
            CurrentState.OnUndoSplit -= state_OnSplitChange;
            CurrentState.OnReset -= state_OnReset;

        }

        void state_OnStart(object sender, EventArgs e)
        {

            updateSplit = "yes";    
            

        }

        void state_OnSplitChange(object sender, EventArgs e)
        {

            updateSplit = "yes";

        }

        void state_OnReset(object sender, TimerPhase e)
        {

            updateSplit = "reset";

        }
        // I do not know what this is for.

        
        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();

    }

  

}