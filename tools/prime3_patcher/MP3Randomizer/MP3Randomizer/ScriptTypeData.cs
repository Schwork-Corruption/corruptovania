using System.Collections.Generic;

namespace MP3Randomizer;

public class ScriptTypeData
{
	public static Dictionary<string, ScriptType> get_all_types()
	{
		List<ScriptType> list = new List<ScriptType>();
		list.Add(ScriptType.import("AVMC", new uint[3] { 626673024u, 837555388u, 4284324222u }));
		list.Add(ScriptType.import("CRLY", new uint[7] { 626673024u, 1155238642u, 751128183u, 3468781874u, 3876183488u, 1231113297u, 3029906468u }));
		list.Add(ScriptType.import("CNTA", new uint[6] { 626673024u, 1896867287u, 3940005819u, 703874812u, 3341921889u, 4236410723u }));
		list.Add(ScriptType.import("SRLY", new uint[2] { 626673024u, 3940005819u }));
		list.Add(ScriptType.import("SLCT", new uint[3] { 626673024u, 2185885383u, 312989874u }));
		list.Add(ScriptType.import("SPFN", new uint[14]
		{
			626673024u, 3098529569u, 2642040685u, 419594393u, 747875061u, 3889133904u, 4207561192u, 2805266597u, 3045152587u, 1067541692u,
			1590660967u, 3629907401u, 319237740u, 2187206164u
		}));
		list.Add(ScriptType.import("MOVI", new uint[9] { 626673024u, 1479247016u, 3986980854u, 915815372u, 2810888384u, 2160487479u, 3791605508u, 2912860031u, 2082905788u }));
		list.Add(ScriptType.import("TXPN", new uint[20]
		{
			626673024u, 1939051527u, 3763617382u, 3370402298u, 3740408821u, 3886823719u, 3573663870u, 2498770524u, 2427073567u, 2082905788u,
			2495617804u, 2933021265u, 903627728u, 4120083231u, 812259768u, 3592577967u, 2715385902u, 2135235209u, 3730199069u, 1580749960u
		}));
		list.Add(ScriptType.import("TIMR", new uint[5] { 626673024u, 1144216319u, 986946353u, 840425464u, 3986980854u }));
		list.Add(ScriptType.import("TEL1", new uint[37]
		{
			626673024u, 837555388u, 3770775556u, 1196149987u, 2840159569u, 3153022221u, 3438265880u, 83971169u, 4193211860u, 1014620449u,
			2389804836u, 1813474774u, 2441225484u, 3309339368u, 3652335951u, 892699325u, 426645465u, 2995730353u, 2714036216u, 2043520380u,
			189939939u, 1903716113u, 774271021u, 1402354280u, 1321170445u, 1637025139u, 1568569761u, 3142714568u, 3084701898u, 80756289u,
			3349672329u, 3745731491u, 2382321268u, 838475744u, 3931714196u, 1448593948u, 3177857133u
		}));
		Dictionary<string, ScriptType> dictionary = new Dictionary<string, ScriptType>();
		foreach (ScriptType item in list)
		{
			dictionary[item.fourCC] = item;
		}
		return dictionary;
	}
}
