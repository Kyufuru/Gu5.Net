using System.Collections.Generic;

namespace Gu5.Core.Trees
{
    /// <summary>
    /// 基础树对象
    /// </summary>
    public class TreeBase : ITree<TreeBase>
    {
        /// <inheritdoc />
        public TreeBase Parent { get; set; }

        /// <inheritdoc/>
        public List<TreeBase> Childs { get; set; } = 
            new List<TreeBase>();

        /// <inheritdoc/>
        public List<TreeBase> Children
        {
            get => Childs;
            set => Childs = value;
        }
    }
}
