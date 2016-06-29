using UnityEngine;
using System.Collections;

public struct TileWorldPos {
	public int x;
	public int y;

	public TileWorldPos(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TileWorldPos))
			return false;
		TileWorldPos pos = (TileWorldPos)obj;
		if (pos.x != x || pos.y != y) {
			return false;
		} else {
			return true;
		}
	}
}
