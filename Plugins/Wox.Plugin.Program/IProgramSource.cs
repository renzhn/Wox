using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Wox.Plugin.Program
{
    public interface IProgramSource
    {
        List<Program> LoadPrograms();
        int BonusPoints { get; set; }
    }

    [Serializable]
    public abstract class AbstractProgramSource : IProgramSource
    {
        public abstract List<Program> LoadPrograms();

        public int BonusPoints
        {
            get; set;
        }

        protected Program CreateEntry(string file)
        {
            var p = new Program()
            {
                Title = Path.GetFileNameWithoutExtension(file),
                IcoPath = file,
                ExecutePath = file
            };
            return p;
        }
    }
}
