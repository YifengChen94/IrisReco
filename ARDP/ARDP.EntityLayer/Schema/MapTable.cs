using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
[Serializable]
public partial class MapTable : TableInfo
{
public const string C_TableName = "Map";

public const string C_MapID = "MapID";

public const string C_MapName = "MapName";

public const string C_MapRelationCode = "MapRelationCode";
public const string C_MapLevel = "MapLevel";
public const string C_MapScale = "MapScale";

public MapTable()
{
_tableName = "Map";
}

protected static MapTable _current;
public static MapTable Current
{
get
{
if (_current == null )
{
Initial();
}
return _current;
}
}

private static void Initial()
{
_current = new MapTable();

_current.Add(C_MapID, new ColumnInfo(C_MapID, "Mapid", true, typeof(string)));

_current.Add(C_MapName, new ColumnInfo(C_MapName, "Mapname", false, typeof(string)));

_current.Add(C_MapRelationCode, new ColumnInfo(C_MapRelationCode, "Maprelationcode", false, typeof(string)));

_current.Add(C_MapLevel, new ColumnInfo(C_MapLevel, "Maplevel", false, typeof(decimal)));

_current.Add(C_MapScale, new ColumnInfo(C_MapScale, "Mapscale", false, typeof(int)));
}


public ColumnInfo MapID
{
get { return this[C_MapID]; }
}

public ColumnInfo MapName
{
get { return this[C_MapName]; }
}

public ColumnInfo MapRelationCode
{
get { return this[C_MapRelationCode]; }
}
public ColumnInfo MapLevel
{
    get { return this[C_MapLevel]; }
}
public ColumnInfo MapScale
{
    get { return this[C_MapScale]; }
}
}
}
