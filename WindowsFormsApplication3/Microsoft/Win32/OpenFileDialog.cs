using System;

namespace Microsoft.Win32
{
    internal class OpenFileDialog
    {
        public string DefaultExt { get; internal set; }
        public string FileName { get; internal set; }
        public string Filter { get; internal set; }

        internal bool? ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}