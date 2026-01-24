namespace Gu5.Net.Core.Trees
{
    /// <summary>
    /// 基础树对象
    /// </summary>
    public class TreeBase : ITree<TreeBase>
    {
        /// <inheritdoc />
        public TreeBase Parent { get; set; } = null!;

        /// <inheritdoc/>
        public List<TreeBase> Childs { get; set; } = [];
    }
}
