using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace GetRowChangedPosition
{
    internal sealed class RowAnalyzer
    {
        /// <summary>
        /// The layer of the adornment.
        /// </summary>
        private readonly IAdornmentLayer layer;

        /// <summary>
        /// Text view where the adornment is created.
        /// </summary>
        private readonly IWpfTextView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowAnalyzer"/> class.
        /// </summary>
        /// <param name="view">Text view to create the adornment for</param>
        public RowAnalyzer(IWpfTextView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.layer = view.GetAdornmentLayer("RowAnalyzer");

            this.view = view;
            this.view.LayoutChanged += this.OnLayoutChanged;
        }


        internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            foreach (ITextViewLine line in e.NewOrReformattedLines)
            {
                this.CreateVisuals(line);
            }
        }

        private void CreateVisuals(ITextViewLine line)
        {
            IWpfTextViewLineCollection textViewLines = this.view.TextViewLines;
            
            int linePosition = 1;
            
            foreach (var snapshotLine in view.TextSnapshot.Lines)
            {
                if (line.Start.Position >= snapshotLine.Start.Position && line.End.Position <= snapshotLine.End.Position)
                {
                    break;
                }
                
                linePosition++;
            }

            linePosition = linePosition;
        }
    }
}
