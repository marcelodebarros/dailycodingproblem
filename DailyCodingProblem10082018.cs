using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyCodingProblem
{
	class DailyCodingProblem10082018
	{
		public void LockUnlock(int val, bool lockUnlock, LockTree root)
		{
			if (root == null) return;
			LockTree tree = root.FindNodeBST(val);
			if (tree != null)
			{
				if (lockUnlock)
				{
					if (tree.Lock())
					{
						Console.WriteLine("Node {0} locked!", val);
					}
					else
					{
						Console.WriteLine("Node {0} could not be locked!", val);
					}
				}
				else
				{
					if (tree.Unlock())
					{
						Console.WriteLine("Node {0} unlocked!", val);
					}
					else
					{
						Console.WriteLine("Node {0} could not be unlocked!", val);
					}
				}
			}
		}

		public LockTree BuildTree()
		{
			LockTree tree = new LockTree(10, null);
			tree.left = new LockTree(5, tree);
			tree.right = new LockTree(15, tree);
			tree.left.left = new LockTree(2, tree.left);
			tree.left.right = new LockTree(8, tree.left);
			tree.right.left = new LockTree(12, tree.right);
			tree.right.right = new LockTree(20, tree.right);
			tree.right.right.left = new LockTree(18, tree.right.right);
			tree.right.right.right = new LockTree(22, tree.right.right);

			return tree;
		}
	}

	class LockTree
	{
		private bool isLocked = false;
		private int countLockedNodes = 0;
		public int val = -1;
		public LockTree left = null;
		public LockTree right = null;
		public LockTree parent = null;

		public LockTree() { }

		public LockTree(int val, LockTree parent)
		{
			this.val = val;
			this.parent = parent;
		}

		public bool Lock()
		{
			if (!isLocked && countLockedNodes == 0)
			{
				this.isLocked = true;
				ChangeCountLockedNodes(1);
				return true;
			}
			return false;
		}

		public bool Unlock()
		{
			if (IsLocked && countLockedNodes == 0)
			{
				this.isLocked = false;
				ChangeCountLockedNodes(-1);
				return true;
			}
			return false;
		}

		public LockTree FindNodeBST(int val)
		{
			if (val == this.val) return this;
			if (val < this.val && this.left != null) return this.left.FindNodeBST(val);
			if (val >= this.val && this.right != null) return this.right.FindNodeBST(val);
			return null;
		}

		public bool IsLocked
		{
			get
			{
				return isLocked;
			}
		}

		private void ChangeCountLockedNodes(int delta)
		{
			if (parent != null)
			{
				parent.countLockedNodes += delta;
				parent.ChangeCountLockedNodes(delta);
			}
		}
	}
}
