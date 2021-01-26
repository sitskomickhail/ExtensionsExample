using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell.Interop;

namespace MyObjectPropertiesExtension
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("da4d1cec-6b0c-4a30-bad7-e8eddae0bad3")]
    public class MyToolWindow : ToolWindowPane
    {
        private ITrackSelection trackSel;
        private SelectionContainer selContainer;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MyToolWindow"/> class.
        /// </summary>
        public MyToolWindow() : base(null)
        {
            this.Caption = "MyToolWindow";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new MyToolWindowControl();
        }

        private ITrackSelection TrackSelection
        {
            get
            {
                if (trackSel == null)
                    trackSel =
                        GetService(typeof(STrackSelection)) as ITrackSelection;
                return trackSel;
            }
        }

        public void UpdateSelection()
        {
            ITrackSelection track = TrackSelection;
            if (track != null)
                track.OnSelectChange((ISelectionContainer)selContainer);
        }

        public void SelectList(ArrayList list)
        {
            selContainer = new SelectionContainer(true, false);
            selContainer.SelectableObjects = list;
            selContainer.SelectedObjects = list;
            UpdateSelection();
        }

        public override void OnToolWindowCreated()
        {
            ArrayList listObjects = new ArrayList();
            listObjects.Add(this);
            SelectList(listObjects);
        }
    }
}
