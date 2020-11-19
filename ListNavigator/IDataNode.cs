﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ListNavigator
{
    public interface IDataNode
    {
        /// <summary>
        /// Name to be displayed in the tree.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Type of the data node.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// This method returns the TreeViewItem corresponding to current node. TreeViewItem of child nodes is also
        /// added to it.
        /// </summary>
        /// <returns></returns>
        TreeViewItem GetItem();

        /// <summary>
        /// Adds a child to the node.
        /// </summary>
        /// <param name="node"></param>
        void AddChild(IDataNode node);

        /// <summary>
        /// Removes a child from the node.
        /// </summary>
        /// <param name="node"></param>
        void RemoveChild(IDataNode node);
    }
}