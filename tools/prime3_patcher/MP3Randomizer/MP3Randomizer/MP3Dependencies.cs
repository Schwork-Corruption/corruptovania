using System;
using System.Collections.Generic;
using System.Text;

namespace MP3Randomizer;

public class MP3Dependencies
{
	public static Dictionary<ulong, Dependency[]> get_file_dependencies()
	{
		Dictionary<ulong, Dependency[]> dictionary = new Dictionary<ulong, Dependency[]>();
		dictionary[11893386419596070465uL] = new Dependency[9]
		{
			Dependency.import(1711217606726147724uL, "PART"),
			Dependency.import(6027450289171150249uL, "PART"),
			Dependency.import(6676219563211487173uL, "PART"),
			Dependency.import(8859443243213060323uL, "PART"),
			Dependency.import(13786906413319162029uL, "ANIM"),
			Dependency.import(8781870449421268817uL, "CMDL"),
			Dependency.import(15970367179005898360uL, "CSKR"),
			Dependency.import(17187453754893088101uL, "CINF"),
			Dependency.import(17173069180456239198uL, "SAND")
		};
		dictionary[7545375166829662025uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(14294579797773761448uL, "TXTR"),
			Dependency.import(11893386419596070465uL, "CHAR"),
			Dependency.import(4029109053143620124uL, "STRG")
		};
		dictionary[18191665387441481222uL] = new Dependency[1] { Dependency.import(16548723040388838987uL, "TXTR") };
		dictionary[2040590680738806279uL] = new Dependency[11]
		{
			Dependency.import(6015387533211301328uL, "PART"),
			Dependency.import(6956411412486139569uL, "ELSC"),
			Dependency.import(12809058436072647621uL, "ELSC"),
			Dependency.import(18324131251209392339uL, "PART"),
			Dependency.import(796302267033227485uL, "CINF"),
			Dependency.import(2431590122456618329uL, "CSKR"),
			Dependency.import(9884726524426460562uL, "CMDL"),
			Dependency.import(7802253989601922551uL, "SAND"),
			Dependency.import(1981024113290903541uL, "ANIM"),
			Dependency.import(14290856390044724757uL, "ANIM"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[624120757386143078uL] = new Dependency[1] { Dependency.import(9859281595864036425uL, "CSMP") };
		dictionary[8704361200960871095uL] = new Dependency[3]
		{
			Dependency.import(2907832395384416708uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(10436899367656329368uL, "STRG")
		};
		dictionary[16543294716448645787uL] = new Dependency[0];
		dictionary[3802225713557459188uL] = new Dependency[3]
		{
			Dependency.import(2239213481996973625uL, "TXTR"),
			Dependency.import(5804640043212311100uL, "TXTR"),
			Dependency.import(16548723040388838987uL, "TXTR")
		};
		dictionary[7767507011937911602uL] = new Dependency[2]
		{
			Dependency.import(3520941364552070592uL, "TXTR"),
			Dependency.import(11628377718743086346uL, "PART")
		};
		dictionary[8614852523655281120uL] = new Dependency[7]
		{
			Dependency.import(11083440669935630801uL, "PART"),
			Dependency.import(10342045281902899174uL, "CMDL"),
			Dependency.import(13506892645770598385uL, "ANIM"),
			Dependency.import(6677071420842842129uL, "CINF"),
			Dependency.import(12760907017370427273uL, "CSKR"),
			Dependency.import(10452523963747535569uL, "SAND"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[10684894363654015796uL] = new Dependency[3]
		{
			Dependency.import(8541036182335174885uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(12807530099206688504uL, "STRG")
		};
		dictionary[15393863491699338341uL] = new Dependency[2]
		{
			Dependency.import(335198071449610687uL, "PART"),
			Dependency.import(15430052131627632779uL, "PART")
		};
		dictionary[10771886776792498981uL] = new Dependency[0];
		dictionary[12120026677630017316uL] = new Dependency[0];
		dictionary[3497988747524935735uL] = new Dependency[8]
		{
			Dependency.import(5955242035972370156uL, "PART"),
			Dependency.import(15168367142111274478uL, "PART"),
			Dependency.import(4960103487419885066uL, "CSKR"),
			Dependency.import(7907600492968194795uL, "CINF"),
			Dependency.import(11266970830946015393uL, "CMDL"),
			Dependency.import(13128096582597185358uL, "SAND"),
			Dependency.import(5536032029763161440uL, "ANIM"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[1645959570383837007uL] = new Dependency[3]
		{
			Dependency.import(1126250934124725529uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(13605690565939857349uL, "STRG")
		};
		dictionary[2868976255724101963uL] = new Dependency[1] { Dependency.import(15559333234627804632uL, "CMDL") };
		dictionary[5426729541768340170uL] = new Dependency[0];
		dictionary[4191745793087347322uL] = new Dependency[14]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(8638964802745882918uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR"),
			Dependency.import(14609421777090153096uL, "TXTR"),
			Dependency.import(6625724135593474413uL, "TXTR"),
			Dependency.import(6261300758903154982uL, "TXTR"),
			Dependency.import(16938765819902311028uL, "TXTR"),
			Dependency.import(7035906686150321394uL, "TXTR"),
			Dependency.import(10778280684008550613uL, "TXTR"),
			Dependency.import(8674147972335797322uL, "TXTR")
		};
		dictionary[6553607357396825409uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(15431095705460510636uL, "TXTR"),
			Dependency.import(9167215608761042889uL, "STRG"),
			Dependency.import(13680536478619729680uL, "CHAR")
		};
		dictionary[6754355035815748370uL] = new Dependency[1] { Dependency.import(11122827809384469770uL, "TXTR") };
		dictionary[6136919230708251016uL] = new Dependency[10]
		{
			Dependency.import(3226721947399655527uL, "PART"),
			Dependency.import(6956411412486139569uL, "ELSC"),
			Dependency.import(12809058436072647621uL, "ELSC"),
			Dependency.import(14091985836596679324uL, "ANIM"),
			Dependency.import(7653634147095690794uL, "CINF"),
			Dependency.import(11415623321072527291uL, "CMDL"),
			Dependency.import(16427871562285274266uL, "CSKR"),
			Dependency.import(12364721121629827691uL, "SAND"),
			Dependency.import(10282481129059022534uL, "ANIM"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[16844651987303611430uL] = new Dependency[3]
		{
			Dependency.import(10319650009266027192uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(1150397881618576192uL, "STRG")
		};
		dictionary[1601595853091338410uL] = new Dependency[2]
		{
			Dependency.import(2239213481996973625uL, "TXTR"),
			Dependency.import(5804640043212311100uL, "TXTR")
		};
		dictionary[6468845420830704274uL] = new Dependency[8]
		{
			Dependency.import(5779794074498722341uL, "PART"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(4846686360843615932uL, "ANIM"),
			Dependency.import(9663933071087354447uL, "ANIM"),
			Dependency.import(10757457519843774881uL, "CMDL"),
			Dependency.import(15617915909168376401uL, "CINF"),
			Dependency.import(18232980430598714615uL, "CSKR"),
			Dependency.import(2819805363307581210uL, "SAND")
		};
		dictionary[11003105356552466074uL] = new Dependency[3]
		{
			Dependency.import(2075824553918357578uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(3098276298772039849uL, "STRG")
		};
		dictionary[13361737445121546779uL] = new Dependency[2]
		{
			Dependency.import(2239213481996973625uL, "TXTR"),
			Dependency.import(5804640043212311100uL, "TXTR")
		};
		dictionary[2352231148816946073uL] = new Dependency[9]
		{
			Dependency.import(2427854098402457927uL, "PART"),
			Dependency.import(14810886615952613649uL, "PART"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(8298502831142843618uL, "ANIM"),
			Dependency.import(1750116006290218556uL, "ANIM"),
			Dependency.import(863971983784147265uL, "CMDL"),
			Dependency.import(3054011477367967969uL, "CINF"),
			Dependency.import(5699264003940197660uL, "CSKR"),
			Dependency.import(11227294079638154735uL, "SAND")
		};
		dictionary[6002275143265498478uL] = new Dependency[3]
		{
			Dependency.import(2535691929122039822uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(313487906538825549uL, "STRG")
		};
		dictionary[13887536408518523848uL] = new Dependency[1] { Dependency.import(16238751108538286977uL, "TXTR") };
		dictionary[13663595385482220419uL] = new Dependency[14]
		{
			Dependency.import(5454697620611632792uL, "ELSC"),
			Dependency.import(6428398227455162866uL, "PART"),
			Dependency.import(8260306578591787557uL, "ELSC"),
			Dependency.import(12717210843211364279uL, "PART"),
			Dependency.import(13251751112344471396uL, "ELSC"),
			Dependency.import(17231217700232593547uL, "PART"),
			Dependency.import(18273517458179118246uL, "PART"),
			Dependency.import(4337431337771538677uL, "ANIM"),
			Dependency.import(1431426173555212027uL, "CSKR"),
			Dependency.import(11821927845286780866uL, "CINF"),
			Dependency.import(13583079734693498220uL, "CMDL"),
			Dependency.import(12033064105329716730uL, "SAND"),
			Dependency.import(13058597170210651565uL, "ANIM"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[8477379539285172597uL] = new Dependency[3]
		{
			Dependency.import(5269142337636114221uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(9802794356238508895uL, "STRG")
		};
		dictionary[17918607277485640015uL] = new Dependency[1] { Dependency.import(16238751108538286977uL, "TXTR") };
		dictionary[4865270349038449909uL] = new Dependency[10]
		{
			Dependency.import(13231381956623708428uL, "ELSC"),
			Dependency.import(14217935261398471855uL, "ELSC"),
			Dependency.import(15133531768320061023uL, "PART"),
			Dependency.import(13640423438147353057uL, "ANIM"),
			Dependency.import(17896641454202588416uL, "ANIM"),
			Dependency.import(6550769727447098165uL, "CSKR"),
			Dependency.import(6599979723913082870uL, "CMDL"),
			Dependency.import(13850428865819061135uL, "CINF"),
			Dependency.import(12503679288299825210uL, "SAND"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[3419731502956601799uL] = new Dependency[3]
		{
			Dependency.import(8353087962113206121uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(1276778310704411534uL, "STRG")
		};
		dictionary[14093194739886489665uL] = new Dependency[1] { Dependency.import(12934080969444126079uL, "TXTR") };
		dictionary[7980038136286965758uL] = new Dependency[10]
		{
			Dependency.import(13231381956623708428uL, "ELSC"),
			Dependency.import(14217935261398471855uL, "ELSC"),
			Dependency.import(15910188092076540606uL, "PART"),
			Dependency.import(12326286237806500161uL, "ANIM"),
			Dependency.import(11485439996104556313uL, "CSKR"),
			Dependency.import(14476987970899305790uL, "CINF"),
			Dependency.import(17102964567674310782uL, "CMDL"),
			Dependency.import(16856962936231582766uL, "SAND"),
			Dependency.import(3418752649061598613uL, "ANIM"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[2506337107259132142uL] = new Dependency[3]
		{
			Dependency.import(11505334210067897373uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(8915061391030355194uL, "STRG")
		};
		dictionary[11201605887730849594uL] = new Dependency[2]
		{
			Dependency.import(12934080969444126079uL, "TXTR"),
			Dependency.import(16548723040388838987uL, "TXTR")
		};
		dictionary[2284319054513284094uL] = new Dependency[11]
		{
			Dependency.import(734753843463105453uL, "ELSC"),
			Dependency.import(8141569286911757542uL, "ELSC"),
			Dependency.import(13231381956623708428uL, "ELSC"),
			Dependency.import(14217935261398471855uL, "ELSC"),
			Dependency.import(7119580164675821185uL, "CSKR"),
			Dependency.import(15743141547838515503uL, "CMDL"),
			Dependency.import(17056320692193595360uL, "CINF"),
			Dependency.import(91349115598229715uL, "SAND"),
			Dependency.import(9486902406172187157uL, "ANIM"),
			Dependency.import(11800796801999800946uL, "ANIM"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[11935457102278706131uL] = new Dependency[3]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(14813427736073482063uL, "TXTR"),
			Dependency.import(7415477939169832116uL, "STRG")
		};
		dictionary[13197794705223359821uL] = new Dependency[3]
		{
			Dependency.import(12934080969444126079uL, "TXTR"),
			Dependency.import(11151033805737300895uL, "TXTR"),
			Dependency.import(18159172482792540629uL, "TXTR")
		};
		dictionary[6723741052681137399uL] = new Dependency[10]
		{
			Dependency.import(5381175866485590705uL, "ELSC"),
			Dependency.import(14243671610499847398uL, "PART"),
			Dependency.import(1010943981605800282uL, "CINF"),
			Dependency.import(2165921073694550343uL, "CMDL"),
			Dependency.import(15642835407240565286uL, "CSKR"),
			Dependency.import(10522402045125534375uL, "SAND"),
			Dependency.import(18331912350379345361uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(4973839121091639151uL, "ANIM"),
			Dependency.import(6138274712540911393uL, "ANIM")
		};
		dictionary[11639329073052934132uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(13779366725339368695uL, "TXTR"),
			Dependency.import(17187466620982092318uL, "STRG"),
			Dependency.import(6723741052681137399uL, "CHAR")
		};
		dictionary[6308182120562325546uL] = new Dependency[0];
		dictionary[17512845949636512769uL] = new Dependency[9]
		{
			Dependency.import(5381175866485590705uL, "ELSC"),
			Dependency.import(14243671610499847398uL, "PART"),
			Dependency.import(18331912350379345361uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(12645644224439289704uL, "ANIM"),
			Dependency.import(4453149617883948264uL, "CMDL"),
			Dependency.import(17128728418063473970uL, "CINF"),
			Dependency.import(18400461120822948280uL, "CSKR"),
			Dependency.import(18429915308824851866uL, "SAND")
		};
		dictionary[5523093293244337731uL] = new Dependency[3]
		{
			Dependency.import(1895205026193515096uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(16162703595497642635uL, "STRG")
		};
		dictionary[10921716073391547936uL] = new Dependency[1] { Dependency.import(7485834586327012175uL, "TXTR") };
		dictionary[14893130060647594764uL] = new Dependency[11]
		{
			Dependency.import(2523643605309117114uL, "PART"),
			Dependency.import(13231381956623708428uL, "ELSC"),
			Dependency.import(13999992786718732438uL, "PART"),
			Dependency.import(14217935261398471855uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(1230284270812005885uL, "CSKR"),
			Dependency.import(5738737950512114245uL, "CMDL"),
			Dependency.import(12415746080444227038uL, "CINF"),
			Dependency.import(6310808410637059381uL, "SAND"),
			Dependency.import(13250717417090371178uL, "ANIM"),
			Dependency.import(15525770588905301109uL, "ANIM")
		};
		dictionary[17455258852243511734uL] = new Dependency[3]
		{
			Dependency.import(7199982271083830228uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(3212239187807032109uL, "STRG")
		};
		dictionary[9740999514871327794uL] = new Dependency[1] { Dependency.import(11122827809384469770uL, "TXTR") };
		dictionary[2771776149459559063uL] = new Dependency[12]
		{
			Dependency.import(5134422414199367817uL, "PART"),
			Dependency.import(8129684481694113938uL, "PART"),
			Dependency.import(8380093890583281415uL, "ELSC"),
			Dependency.import(9208835509081959410uL, "ELSC"),
			Dependency.import(12432920437641557576uL, "PART"),
			Dependency.import(304664936196961023uL, "ANIM"),
			Dependency.import(17773508300021585687uL, "ANIM"),
			Dependency.import(1943417976360263108uL, "CINF"),
			Dependency.import(4248064363090303320uL, "CMDL"),
			Dependency.import(4253903636868898864uL, "CSKR"),
			Dependency.import(11733723092768007992uL, "SAND"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[3614430451894776096uL] = new Dependency[3]
		{
			Dependency.import(1126671102353821959uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(4416236190371632066uL, "STRG")
		};
		dictionary[13821521612853639816uL] = new Dependency[0];
		dictionary[106639094015363349uL] = new Dependency[11]
		{
			Dependency.import(5537424536592299764uL, "PART"),
			Dependency.import(15862856093148310225uL, "ANIM"),
			Dependency.import(1860955988695486048uL, "CINF"),
			Dependency.import(11508097013628258740uL, "CSKR"),
			Dependency.import(13612974769584238489uL, "CMDL"),
			Dependency.import(8647870601746458485uL, "SAND"),
			Dependency.import(14399008385960734577uL, "ANIM"),
			Dependency.import(14871525828662026254uL, "PART"),
			Dependency.import(16695874960007568107uL, "SWHC"),
			Dependency.import(16771010662076871884uL, "PART"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[15789242381479631100uL] = new Dependency[3]
		{
			Dependency.import(2022133347491214052uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(9458468024466603392uL, "STRG")
		};
		dictionary[11713285777917155342uL] = new Dependency[1] { Dependency.import(6899931478000052142uL, "TXTR") };
		dictionary[12917629505603173694uL] = new Dependency[10]
		{
			Dependency.import(4711182799240374607uL, "ELSC"),
			Dependency.import(5537424536592299764uL, "PART"),
			Dependency.import(6410910641488130515uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(10523949893010597298uL, "ANIM"),
			Dependency.import(567120767343610054uL, "CMDL"),
			Dependency.import(10945569807846212209uL, "CINF"),
			Dependency.import(17154094186830986601uL, "CSKR"),
			Dependency.import(5049991750667669257uL, "SAND"),
			Dependency.import(9086031835985505390uL, "ANIM")
		};
		dictionary[7836523622218474582uL] = new Dependency[3]
		{
			Dependency.import(4341264361231621259uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(1264259019669362799uL, "STRG")
		};
		dictionary[16477591010988705884uL] = new Dependency[1] { Dependency.import(16548723040388838987uL, "TXTR") };
		dictionary[7921296981517537547uL] = new Dependency[10]
		{
			Dependency.import(2502018228360635366uL, "PART"),
			Dependency.import(9334909926879874963uL, "ELSC"),
			Dependency.import(9505311470191055195uL, "PART"),
			Dependency.import(18280879424342257012uL, "PART"),
			Dependency.import(15201396005654837044uL, "ANIM"),
			Dependency.import(730317664718241342uL, "CMDL"),
			Dependency.import(1234718022661897585uL, "CINF"),
			Dependency.import(13687147974507042117uL, "CSKR"),
			Dependency.import(5944597854167272362uL, "SAND"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[17763813284819343871uL] = new Dependency[3]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(17316924506676194237uL, "TXTR"),
			Dependency.import(3668261853445923953uL, "STRG")
		};
		dictionary[10501061908192671136uL] = new Dependency[2]
		{
			Dependency.import(6890583768696084520uL, "TXTR"),
			Dependency.import(12323836628497659026uL, "TXTR")
		};
		dictionary[11912949773674010895uL] = new Dependency[10]
		{
			Dependency.import(2502018228360635366uL, "PART"),
			Dependency.import(8564083123465431748uL, "ELSC"),
			Dependency.import(9505311470191055195uL, "PART"),
			Dependency.import(17029398643147759798uL, "PART"),
			Dependency.import(9693021767829884442uL, "ANIM"),
			Dependency.import(2136473733240698362uL, "CINF"),
			Dependency.import(8067917701288644826uL, "CMDL"),
			Dependency.import(8780115325370813118uL, "CSKR"),
			Dependency.import(13890839741271422162uL, "SAND"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[699483515243878166uL] = new Dependency[3]
		{
			Dependency.import(9134411992159837230uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(10208258969470925472uL, "STRG")
		};
		dictionary[2432839730309085385uL] = new Dependency[2]
		{
			Dependency.import(2239213481996973625uL, "TXTR"),
			Dependency.import(5804640043212311100uL, "TXTR")
		};
		dictionary[17770190758093317702uL] = new Dependency[10]
		{
			Dependency.import(2502018228360635366uL, "PART"),
			Dependency.import(8239913231940481401uL, "ELSC"),
			Dependency.import(9505311470191055195uL, "PART"),
			Dependency.import(17626662339085539451uL, "ELSC"),
			Dependency.import(18211454344723294548uL, "ANIM"),
			Dependency.import(1339607789165987829uL, "CMDL"),
			Dependency.import(2831025280974679626uL, "CSKR"),
			Dependency.import(17618791458181397912uL, "CINF"),
			Dependency.import(5950510621749934095uL, "SAND"),
			Dependency.import(624120757386143078uL, "CAUD")
		};
		dictionary[5689915533322560111uL] = new Dependency[3]
		{
			Dependency.import(10679571758992727636uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(14741418361591746017uL, "STRG")
		};
		dictionary[11110070866502191287uL] = new Dependency[2]
		{
			Dependency.import(12934080969444126079uL, "TXTR"),
			Dependency.import(16548723040388838987uL, "TXTR")
		};
		dictionary[8613152236454707754uL] = new Dependency[8]
		{
			Dependency.import(8476307700516476269uL, "PART"),
			Dependency.import(11020338764084084676uL, "PART"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(4441504836776907756uL, "CINF"),
			Dependency.import(5702116752564501648uL, "CMDL"),
			Dependency.import(15609796381647515469uL, "CSKR"),
			Dependency.import(5098417903370955915uL, "SAND"),
			Dependency.import(2380141296651107894uL, "ANIM")
		};
		dictionary[15849003250839173501uL] = new Dependency[3]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(17877862508334448139uL, "TXTR"),
			Dependency.import(3928668606782165410uL, "STRG")
		};
		dictionary[10709817540059571937uL] = new Dependency[0];
		dictionary[5208227680257687687uL] = new Dependency[9]
		{
			Dependency.import(6027450289171150249uL, "PART"),
			Dependency.import(8859443243213060323uL, "PART"),
			Dependency.import(12078401793920499848uL, "SWHC"),
			Dependency.import(13999293194620162303uL, "SWHC"),
			Dependency.import(8297375650459260094uL, "CINF"),
			Dependency.import(11204464193328716260uL, "CMDL"),
			Dependency.import(11554219199811911008uL, "CSKR"),
			Dependency.import(8594630836017620224uL, "SAND"),
			Dependency.import(2993925259105052104uL, "ANIM")
		};
		dictionary[7486728626578854846uL] = new Dependency[4]
		{
			Dependency.import(1859725282092728003uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(5208227680257687687uL, "CHAR"),
			Dependency.import(5135930592874982168uL, "STRG")
		};
		dictionary[17462046769283114905uL] = new Dependency[1] { Dependency.import(16548723040388838987uL, "TXTR") };
		dictionary[8613152236454707754uL] = new Dependency[8]
		{
			Dependency.import(8476307700516476269uL, "PART"),
			Dependency.import(11020338764084084676uL, "PART"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(4441504836776907756uL, "CINF"),
			Dependency.import(5702116752564501648uL, "CMDL"),
			Dependency.import(15609796381647515469uL, "CSKR"),
			Dependency.import(5098417903370955915uL, "SAND"),
			Dependency.import(2380141296651107894uL, "ANIM")
		};
		dictionary[15849003250839173501uL] = new Dependency[3]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(17877862508334448139uL, "TXTR"),
			Dependency.import(3928668606782165410uL, "STRG")
		};
		dictionary[10709817540059571937uL] = new Dependency[0];
		dictionary[17350482979715835806uL] = new Dependency[6]
		{
			Dependency.import(3684660078304740131uL, "PART"),
			Dependency.import(9880708269707785279uL, "ANIM"),
			Dependency.import(4000715797499115033uL, "CINF"),
			Dependency.import(8628028762060951037uL, "CSKR"),
			Dependency.import(13216379475820520937uL, "CMDL"),
			Dependency.import(2178802456762447785uL, "SAND")
		};
		dictionary[7771942961434651926uL] = new Dependency[0];
		dictionary[8714149123433208933uL] = new Dependency[10]
		{
			Dependency.import(5381175866485590705uL, "ELSC"),
			Dependency.import(14243671610499847398uL, "PART"),
			Dependency.import(18331912350379345361uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(3850246859562754413uL, "CINF"),
			Dependency.import(12562573896413532156uL, "CMDL"),
			Dependency.import(14036551033045038249uL, "CSKR"),
			Dependency.import(7587447478059061330uL, "SAND"),
			Dependency.import(1362393557420411429uL, "ANIM"),
			Dependency.import(6364072689069914177uL, "ANIM")
		};
		dictionary[12873054735025880152uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(15292116912001593738uL, "TXTR"),
			Dependency.import(7728753299762273302uL, "STRG"),
			Dependency.import(8714149123433208933uL, "CHAR")
		};
		dictionary[6381202050529215614uL] = new Dependency[0];
		dictionary[18311456839351366342uL] = new Dependency[10]
		{
			Dependency.import(5381175866485590705uL, "ELSC"),
			Dependency.import(14243671610499847398uL, "PART"),
			Dependency.import(1303625010544438483uL, "CSKR"),
			Dependency.import(4137268101395742114uL, "CINF"),
			Dependency.import(8551934603131446244uL, "CMDL"),
			Dependency.import(17866468387280615187uL, "SAND"),
			Dependency.import(18331912350379345361uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(4973839121091639151uL, "ANIM"),
			Dependency.import(9156196855062202139uL, "ANIM")
		};
		dictionary[518191066736303415uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(2059797689186040252uL, "STRG"),
			Dependency.import(18311456839351366342uL, "CHAR"),
			Dependency.import(16081072595938795738uL, "TXTR")
		};
		dictionary[12510280824551341827uL] = new Dependency[2]
		{
			Dependency.import(16238751108538286977uL, "TXTR"),
			Dependency.import(7485834586327012175uL, "TXTR")
		};
		dictionary[15553743462035859767uL] = new Dependency[6]
		{
			Dependency.import(4750116281629688182uL, "ANIM"),
			Dependency.import(1416399779673537039uL, "ANIM"),
			Dependency.import(10024196604997912563uL, "CINF"),
			Dependency.import(15612690161058074353uL, "CSKR"),
			Dependency.import(18207520845647290011uL, "CMDL"),
			Dependency.import(9082657087262834231uL, "SAND")
		};
		dictionary[16263001300169656283uL] = new Dependency[4]
		{
			Dependency.import(2216802446791340033uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(9341600575215989082uL, "STRG"),
			Dependency.import(15553743462035859767uL, "CHAR")
		};
		dictionary[16191957328597180590uL] = new Dependency[1] { Dependency.import(6890583768696084520uL, "TXTR") };
		dictionary[2194870872166309214uL] = new Dependency[7]
		{
			Dependency.import(6991011420585764971uL, "PART"),
			Dependency.import(10550689572253757517uL, "ANIM"),
			Dependency.import(5623185356551054190uL, "ANIM"),
			Dependency.import(11726552612436390738uL, "CMDL"),
			Dependency.import(13510436779201952792uL, "CINF"),
			Dependency.import(15456319317506357623uL, "CSKR"),
			Dependency.import(3189994234944054442uL, "SAND")
		};
		dictionary[11079747312172636793uL] = new Dependency[4]
		{
			Dependency.import(12255338748243424809uL, "TXTR"),
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(17328790051365320892uL, "STRG"),
			Dependency.import(2194870872166309214uL, "CHAR")
		};
		dictionary[1635417707669059681uL] = new Dependency[1] { Dependency.import(14872128411242869877uL, "TXTR") };
		dictionary[6470686624252149608uL] = new Dependency[7]
		{
			Dependency.import(14004861904333728930uL, "PART"),
			Dependency.import(3777351512367687559uL, "CINF"),
			Dependency.import(8565354598124945382uL, "CSKR"),
			Dependency.import(15715050417915105304uL, "CMDL"),
			Dependency.import(17418969963892099647uL, "ANIM"),
			Dependency.import(11686398402952667579uL, "SAND"),
			Dependency.import(11322130734825997024uL, "ANIM")
		};
		dictionary[2678434468859682550uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(6470686624252149608uL, "CHAR"),
			Dependency.import(17437271824696891448uL, "TXTR"),
			Dependency.import(17162883210240030991uL, "STRG")
		};
		dictionary[1710512319103653378uL] = new Dependency[1] { Dependency.import(16238751108538286977uL, "TXTR") };
		dictionary[12652616393146428157uL] = new Dependency[1] { Dependency.import(12231246145000234322uL, "TXTR") };
		dictionary[6015387533211301328uL] = new Dependency[1] { Dependency.import(14785641002583583802uL, "TXTR") };
		dictionary[6956411412486139569uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[12809058436072647621uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[18324131251209392339uL] = new Dependency[1] { Dependency.import(426468189646273827uL, "TXTR") };
		dictionary[796302267033227485uL] = new Dependency[0];
		dictionary[2431590122456618329uL] = new Dependency[0];
		dictionary[9884726524426460562uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(916541053714299711uL, "TXTR"),
			Dependency.import(1367859465012113706uL, "TXTR"),
			Dependency.import(1526862528106763475uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[7802253989601922551uL] = new Dependency[0];
		dictionary[1981024113290903541uL] = new Dependency[0];
		dictionary[14290856390044724757uL] = new Dependency[0];
		dictionary[9859281595864036425uL] = new Dependency[0];
		dictionary[2907832395384416708uL] = new Dependency[0];
		dictionary[10436899367656329368uL] = new Dependency[0];
		dictionary[2239213481996973625uL] = new Dependency[0];
		dictionary[5804640043212311100uL] = new Dependency[0];
		dictionary[16548723040388838987uL] = new Dependency[0];
		dictionary[3520941364552070592uL] = new Dependency[0];
		dictionary[11628377718743086346uL] = new Dependency[1] { Dependency.import(16077859690526271937uL, "TXTR") };
		dictionary[11083440669935630801uL] = new Dependency[1] { Dependency.import(6369365994490099692uL, "TXTR") };
		dictionary[10342045281902899174uL] = new Dependency[3]
		{
			Dependency.import(9273539126471894336uL, "TXTR"),
			Dependency.import(3587137238317476971uL, "TXTR"),
			Dependency.import(10342831389196881573uL, "TXTR")
		};
		dictionary[13506892645770598385uL] = new Dependency[0];
		dictionary[6677071420842842129uL] = new Dependency[0];
		dictionary[12760907017370427273uL] = new Dependency[0];
		dictionary[10452523963747535569uL] = new Dependency[0];
		dictionary[8541036182335174885uL] = new Dependency[0];
		dictionary[12807530099206688504uL] = new Dependency[0];
		dictionary[335198071449610687uL] = new Dependency[1] { Dependency.import(15482233503230157426uL, "TXTR") };
		dictionary[15430052131627632779uL] = new Dependency[1] { Dependency.import(12490410757585127952uL, "TXTR") };
		dictionary[5955242035972370156uL] = new Dependency[1] { Dependency.import(5826416173635500595uL, "TXTR") };
		dictionary[15168367142111274478uL] = new Dependency[2]
		{
			Dependency.import(426468189646273827uL, "TXTR"),
			Dependency.import(4993817561204883452uL, "PART")
		};
		dictionary[4960103487419885066uL] = new Dependency[0];
		dictionary[7907600492968194795uL] = new Dependency[0];
		dictionary[11266970830946015393uL] = new Dependency[3]
		{
			Dependency.import(11409674055898906546uL, "TXTR"),
			Dependency.import(5638686474237531170uL, "TXTR"),
			Dependency.import(6027681196154124096uL, "TXTR")
		};
		dictionary[13128096582597185358uL] = new Dependency[0];
		dictionary[5536032029763161440uL] = new Dependency[0];
		dictionary[1126250934124725529uL] = new Dependency[0];
		dictionary[13605690565939857349uL] = new Dependency[0];
		dictionary[15559333234627804632uL] = new Dependency[1] { Dependency.import(11112573284177442094uL, "TXTR") };
		dictionary[297381736347806104uL] = new Dependency[0];
		dictionary[3042119755723076793uL] = new Dependency[0];
		dictionary[6842713676913497667uL] = new Dependency[0];
		dictionary[6924694992144286574uL] = new Dependency[0];
		dictionary[7389617915147675672uL] = new Dependency[0];
		dictionary[8638964802745882918uL] = new Dependency[0];
		dictionary[16264489293619408488uL] = new Dependency[0];
		dictionary[14609421777090153096uL] = new Dependency[0];
		dictionary[6625724135593474413uL] = new Dependency[0];
		dictionary[6261300758903154982uL] = new Dependency[0];
		dictionary[16938765819902311028uL] = new Dependency[0];
		dictionary[7035906686150321394uL] = new Dependency[0];
		dictionary[10778280684008550613uL] = new Dependency[0];
		dictionary[8674147972335797322uL] = new Dependency[0];
		dictionary[15431095705460510636uL] = new Dependency[0];
		dictionary[9167215608761042889uL] = new Dependency[1] { Dependency.import(11122827809384469770uL, "TXTR") };
		dictionary[13680536478619729680uL] = new Dependency[10]
		{
			Dependency.import(5381175866485590705uL, "ELSC"),
			Dependency.import(14243671610499847398uL, "PART"),
			Dependency.import(18331912350379345361uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(1148588453071853667uL, "ANIM"),
			Dependency.import(4191745793087347322uL, "CMDL"),
			Dependency.import(4521321244001047955uL, "CINF"),
			Dependency.import(10520951488014605151uL, "CSKR"),
			Dependency.import(11779171333706053077uL, "SAND"),
			Dependency.import(14479419399884613012uL, "ANIM")
		};
		dictionary[11122827809384469770uL] = new Dependency[0];
		dictionary[3226721947399655527uL] = new Dependency[1] { Dependency.import(6212921745494877931uL, "TXTR") };
		dictionary[14091985836596679324uL] = new Dependency[0];
		dictionary[7653634147095690794uL] = new Dependency[0];
		dictionary[11415623321072527291uL] = new Dependency[10]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(916541053714299711uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(4591936007374415792uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(13725179759385404928uL, "TXTR"),
			Dependency.import(16148999342324292150uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[16427871562285274266uL] = new Dependency[0];
		dictionary[12364721121629827691uL] = new Dependency[0];
		dictionary[10282481129059022534uL] = new Dependency[0];
		dictionary[10319650009266027192uL] = new Dependency[0];
		dictionary[1150397881618576192uL] = new Dependency[0];
		dictionary[5779794074498722341uL] = new Dependency[1] { Dependency.import(14785641002583583802uL, "TXTR") };
		dictionary[4846686360843615932uL] = new Dependency[0];
		dictionary[9663933071087354447uL] = new Dependency[0];
		dictionary[10757457519843774881uL] = new Dependency[10]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(916541053714299711uL, "TXTR"),
			Dependency.import(1367859465012113706uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(13725179759385404928uL, "TXTR"),
			Dependency.import(14208680886519569230uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[15617915909168376401uL] = new Dependency[0];
		dictionary[18232980430598714615uL] = new Dependency[0];
		dictionary[2819805363307581210uL] = new Dependency[0];
		dictionary[2075824553918357578uL] = new Dependency[0];
		dictionary[3098276298772039849uL] = new Dependency[0];
		dictionary[2427854098402457927uL] = new Dependency[2]
		{
			Dependency.import(7849392829122749750uL, "PART"),
			Dependency.import(2960391167552239106uL, "TXTR")
		};
		dictionary[14810886615952613649uL] = new Dependency[4]
		{
			Dependency.import(5461336859955469143uL, "PART"),
			Dependency.import(14271013225668573728uL, "PART"),
			Dependency.import(17487682849986754402uL, "CMDL"),
			Dependency.import(2960391167552239106uL, "TXTR")
		};
		dictionary[8298502831142843618uL] = new Dependency[0];
		dictionary[1750116006290218556uL] = new Dependency[0];
		dictionary[863971983784147265uL] = new Dependency[7]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(10803712534093190762uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[3054011477367967969uL] = new Dependency[0];
		dictionary[5699264003940197660uL] = new Dependency[0];
		dictionary[11227294079638154735uL] = new Dependency[0];
		dictionary[2535691929122039822uL] = new Dependency[0];
		dictionary[313487906538825549uL] = new Dependency[0];
		dictionary[16238751108538286977uL] = new Dependency[0];
		dictionary[5454697620611632792uL] = new Dependency[0];
		dictionary[6428398227455162866uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[8260306578591787557uL] = new Dependency[0];
		dictionary[12717210843211364279uL] = new Dependency[1] { Dependency.import(9003196894612281792uL, "TXTR") };
		dictionary[13251751112344471396uL] = new Dependency[0];
		dictionary[17231217700232593547uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[18273517458179118246uL] = new Dependency[4]
		{
			Dependency.import(42004163459470017uL, "PART"),
			Dependency.import(15015147463261568946uL, "PART"),
			Dependency.import(15268439100179651933uL, "PART"),
			Dependency.import(17644497126251177151uL, "PART")
		};
		dictionary[4337431337771538677uL] = new Dependency[0];
		dictionary[1431426173555212027uL] = new Dependency[0];
		dictionary[11821927845286780866uL] = new Dependency[0];
		dictionary[13583079734693498220uL] = new Dependency[7]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR"),
			Dependency.import(16315094747931539764uL, "TXTR")
		};
		dictionary[12033064105329716730uL] = new Dependency[0];
		dictionary[13058597170210651565uL] = new Dependency[0];
		dictionary[5269142337636114221uL] = new Dependency[0];
		dictionary[9802794356238508895uL] = new Dependency[0];
		dictionary[13231381956623708428uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[14217935261398471855uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[15133531768320061023uL] = new Dependency[2]
		{
			Dependency.import(789620340993680665uL, "CMDL"),
			Dependency.import(16498892038684460011uL, "TXTR")
		};
		dictionary[13640423438147353057uL] = new Dependency[0];
		dictionary[17896641454202588416uL] = new Dependency[0];
		dictionary[6550769727447098165uL] = new Dependency[0];
		dictionary[6599979723913082870uL] = new Dependency[7]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7262126989566451347uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[13850428865819061135uL] = new Dependency[0];
		dictionary[12503679288299825210uL] = new Dependency[0];
		dictionary[8353087962113206121uL] = new Dependency[0];
		dictionary[1276778310704411534uL] = new Dependency[0];
		dictionary[12934080969444126079uL] = new Dependency[0];
		dictionary[15910188092076540606uL] = new Dependency[2]
		{
			Dependency.import(789620340993680665uL, "CMDL"),
			Dependency.import(16498892038684460011uL, "TXTR")
		};
		dictionary[12326286237806500161uL] = new Dependency[0];
		dictionary[11485439996104556313uL] = new Dependency[0];
		dictionary[14476987970899305790uL] = new Dependency[0];
		dictionary[17102964567674310782uL] = new Dependency[7]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7262126989566451347uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[16856962936231582766uL] = new Dependency[0];
		dictionary[3418752649061598613uL] = new Dependency[0];
		dictionary[11505334210067897373uL] = new Dependency[0];
		dictionary[8915061391030355194uL] = new Dependency[0];
		dictionary[734753843463105453uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[8141569286911757542uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[7119580164675821185uL] = new Dependency[0];
		dictionary[15743141547838515503uL] = new Dependency[7]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(10188840227710188653uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[17056320692193595360uL] = new Dependency[0];
		dictionary[91349115598229715uL] = new Dependency[0];
		dictionary[9486902406172187157uL] = new Dependency[0];
		dictionary[11800796801999800946uL] = new Dependency[0];
		dictionary[14813427736073482063uL] = new Dependency[0];
		dictionary[7415477939169832116uL] = new Dependency[0];
		dictionary[11151033805737300895uL] = new Dependency[0];
		dictionary[18159172482792540629uL] = new Dependency[0];
		dictionary[5381175866485590705uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[14243671610499847398uL] = new Dependency[2]
		{
			Dependency.import(1520420442143038911uL, "PART"),
			Dependency.import(10436227703337796794uL, "TXTR")
		};
		dictionary[1010943981605800282uL] = new Dependency[0];
		dictionary[2165921073694550343uL] = new Dependency[10]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(630393481592510399uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(10043071345413407226uL, "TXTR"),
			Dependency.import(13432154628010637490uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR"),
			Dependency.import(10342831389196881573uL, "TXTR")
		};
		dictionary[15642835407240565286uL] = new Dependency[0];
		dictionary[10522402045125534375uL] = new Dependency[0];
		dictionary[18331912350379345361uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[4973839121091639151uL] = new Dependency[0];
		dictionary[6138274712540911393uL] = new Dependency[0];
		dictionary[13779366725339368695uL] = new Dependency[0];
		dictionary[17187466620982092318uL] = new Dependency[2]
		{
			Dependency.import(7485834586327012175uL, "TXTR"),
			Dependency.import(16548723040388838987uL, "TXTR")
		};
		dictionary[12645644224439289704uL] = new Dependency[0];
		dictionary[4453149617883948264uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(2571297758885023326uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7194714416708734120uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(13432154628010637490uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[17128728418063473970uL] = new Dependency[0];
		dictionary[18400461120822948280uL] = new Dependency[0];
		dictionary[18429915308824851866uL] = new Dependency[0];
		dictionary[1895205026193515096uL] = new Dependency[0];
		dictionary[16162703595497642635uL] = new Dependency[0];
		dictionary[7485834586327012175uL] = new Dependency[0];
		dictionary[2523643605309117114uL] = new Dependency[1] { Dependency.import(1753372928331652130uL, "TXTR") };
		dictionary[13999992786718732438uL] = new Dependency[0];
		dictionary[1230284270812005885uL] = new Dependency[0];
		dictionary[5738737950512114245uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(2966682990408583370uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(8761175084044499119uL, "TXTR"),
			Dependency.import(10037187538736634909uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[12415746080444227038uL] = new Dependency[0];
		dictionary[6310808410637059381uL] = new Dependency[0];
		dictionary[13250717417090371178uL] = new Dependency[0];
		dictionary[15525770588905301109uL] = new Dependency[0];
		dictionary[7199982271083830228uL] = new Dependency[0];
		dictionary[3212239187807032109uL] = new Dependency[0];
		dictionary[5134422414199367817uL] = new Dependency[1] { Dependency.import(15401599445244434244uL, "TXTR") };
		dictionary[8129684481694113938uL] = new Dependency[2]
		{
			Dependency.import(1846963830496455397uL, "PART"),
			Dependency.import(2960391167552239106uL, "TXTR")
		};
		dictionary[8380093890583281415uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[9208835509081959410uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[12432920437641557576uL] = new Dependency[0];
		dictionary[304664936196961023uL] = new Dependency[0];
		dictionary[17773508300021585687uL] = new Dependency[0];
		dictionary[1943417976360263108uL] = new Dependency[0];
		dictionary[4248064363090303320uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(4540327826191764659uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7021745000469995088uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(14765731490896820223uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[4253903636868898864uL] = new Dependency[0];
		dictionary[11733723092768007992uL] = new Dependency[0];
		dictionary[1126671102353821959uL] = new Dependency[0];
		dictionary[4416236190371632066uL] = new Dependency[0];
		dictionary[5537424536592299764uL] = new Dependency[1] { Dependency.import(14785641002583583802uL, "TXTR") };
		dictionary[15862856093148310225uL] = new Dependency[0];
		dictionary[1860955988695486048uL] = new Dependency[0];
		dictionary[11508097013628258740uL] = new Dependency[0];
		dictionary[13612974769584238489uL] = new Dependency[10]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(1941599378631452943uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(4905017968892775931uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(13649133105140475653uL, "TXTR"),
			Dependency.import(14765632745460815128uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[8647870601746458485uL] = new Dependency[0];
		dictionary[14399008385960734577uL] = new Dependency[0];
		dictionary[14871525828662026254uL] = new Dependency[1] { Dependency.import(6796334216188807626uL, "CMDL") };
		dictionary[16695874960007568107uL] = new Dependency[0];
		dictionary[16771010662076871884uL] = new Dependency[1] { Dependency.import(14785641002583583802uL, "TXTR") };
		dictionary[2022133347491214052uL] = new Dependency[0];
		dictionary[9458468024466603392uL] = new Dependency[0];
		dictionary[6899931478000052142uL] = new Dependency[0];
		dictionary[4711182799240374607uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[6410910641488130515uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[10523949893010597298uL] = new Dependency[0];
		dictionary[567120767343610054uL] = new Dependency[10]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(1941599378631452943uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(4905017968892775931uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(13649133105140475653uL, "TXTR"),
			Dependency.import(14765632745460815128uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[10945569807846212209uL] = new Dependency[0];
		dictionary[17154094186830986601uL] = new Dependency[0];
		dictionary[5049991750667669257uL] = new Dependency[0];
		dictionary[9086031835985505390uL] = new Dependency[0];
		dictionary[4341264361231621259uL] = new Dependency[0];
		dictionary[1264259019669362799uL] = new Dependency[0];
		dictionary[2502018228360635366uL] = new Dependency[3]
		{
			Dependency.import(2994560928401112936uL, "PART"),
			Dependency.import(6294621317328383029uL, "CMDL"),
			Dependency.import(7376337380674920252uL, "PART")
		};
		dictionary[9334909926879874963uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[9505311470191055195uL] = new Dependency[1] { Dependency.import(6369365994490099692uL, "TXTR") };
		dictionary[18280879424342257012uL] = new Dependency[1] { Dependency.import(10649367674338706376uL, "TXTR") };
		dictionary[15201396005654837044uL] = new Dependency[0];
		dictionary[730317664718241342uL] = new Dependency[7]
		{
			Dependency.import(2910547187509282632uL, "TXTR"),
			Dependency.import(6077173232983826027uL, "TXTR"),
			Dependency.import(6363351949113548418uL, "TXTR"),
			Dependency.import(7897313984779302724uL, "TXTR"),
			Dependency.import(14329783064598644021uL, "TXTR"),
			Dependency.import(14769074767759382748uL, "TXTR"),
			Dependency.import(16863456863476071871uL, "TXTR")
		};
		dictionary[1234718022661897585uL] = new Dependency[0];
		dictionary[13687147974507042117uL] = new Dependency[0];
		dictionary[5944597854167272362uL] = new Dependency[0];
		dictionary[17316924506676194237uL] = new Dependency[0];
		dictionary[3668261853445923953uL] = new Dependency[0];
		dictionary[6890583768696084520uL] = new Dependency[0];
		dictionary[12323836628497659026uL] = new Dependency[0];
		dictionary[8564083123465431748uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[17029398643147759798uL] = new Dependency[1] { Dependency.import(17448131538863483558uL, "TXTR") };
		dictionary[9693021767829884442uL] = new Dependency[0];
		dictionary[2136473733240698362uL] = new Dependency[0];
		dictionary[8067917701288644826uL] = new Dependency[1] { Dependency.import(12122950288832508460uL, "TXTR") };
		dictionary[8780115325370813118uL] = new Dependency[0];
		dictionary[13890839741271422162uL] = new Dependency[0];
		dictionary[9134411992159837230uL] = new Dependency[0];
		dictionary[10208258969470925472uL] = new Dependency[0];
		dictionary[8239913231940481401uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[17626662339085539451uL] = new Dependency[1] { Dependency.import(3992291768341420288uL, "TXTR") };
		dictionary[18211454344723294548uL] = new Dependency[0];
		dictionary[1339607789165987829uL] = new Dependency[4]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(9324378830559852728uL, "TXTR"),
			Dependency.import(13035985192652736893uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[2831025280974679626uL] = new Dependency[0];
		dictionary[17618791458181397912uL] = new Dependency[0];
		dictionary[5950510621749934095uL] = new Dependency[0];
		dictionary[10679571758992727636uL] = new Dependency[0];
		dictionary[14741418361591746017uL] = new Dependency[0];
		dictionary[8476307700516476269uL] = new Dependency[1] { Dependency.import(15679385690788679838uL, "TXTR") };
		dictionary[11020338764084084676uL] = new Dependency[1] { Dependency.import(15679385690788679838uL, "TXTR") };
		dictionary[4441504836776907756uL] = new Dependency[0];
		dictionary[5702116752564501648uL] = new Dependency[4]
		{
			Dependency.import(1423849603490678902uL, "TXTR"),
			Dependency.import(6831485495704885852uL, "TXTR"),
			Dependency.import(7328965053795114852uL, "TXTR"),
			Dependency.import(8094943435699173376uL, "TXTR")
		};
		dictionary[15609796381647515469uL] = new Dependency[0];
		dictionary[5098417903370955915uL] = new Dependency[0];
		dictionary[2380141296651107894uL] = new Dependency[0];
		dictionary[17877862508334448139uL] = new Dependency[0];
		dictionary[3928668606782165410uL] = new Dependency[0];
		dictionary[6027450289171150249uL] = new Dependency[2]
		{
			Dependency.import(789620340993680665uL, "CMDL"),
			Dependency.import(16498892038684460011uL, "TXTR")
		};
		dictionary[8859443243213060323uL] = new Dependency[1] { Dependency.import(16660306179454351710uL, "CMDL") };
		dictionary[12078401793920499848uL] = new Dependency[1] { Dependency.import(7638577061319612875uL, "TXTR") };
		dictionary[13999293194620162303uL] = new Dependency[0];
		dictionary[8297375650459260094uL] = new Dependency[0];
		dictionary[11204464193328716260uL] = new Dependency[16]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(1366596482873901474uL, "TXTR"),
			Dependency.import(3227024819207168511uL, "TXTR"),
			Dependency.import(3865010957015369388uL, "TXTR"),
			Dependency.import(4623210170165220070uL, "TXTR"),
			Dependency.import(5684161697306486034uL, "TXTR"),
			Dependency.import(6788018768710113278uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7092616580311672322uL, "TXTR"),
			Dependency.import(8410027965685754383uL, "TXTR"),
			Dependency.import(15380771469234194988uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR"),
			Dependency.import(16495754193156511048uL, "TXTR"),
			Dependency.import(4015124079987390152uL, "TXTR"),
			Dependency.import(12166129107566771715uL, "TXTR"),
			Dependency.import(17195671189039121193uL, "TXTR")
		};
		dictionary[11554219199811911008uL] = new Dependency[0];
		dictionary[8594630836017620224uL] = new Dependency[0];
		dictionary[2993925259105052104uL] = new Dependency[0];
		dictionary[1859725282092728003uL] = new Dependency[0];
		dictionary[5135930592874982168uL] = new Dependency[1] { Dependency.import(16548723040388838987uL, "TXTR") };
		dictionary[3684660078304740131uL] = new Dependency[3]
		{
			Dependency.import(7372782559495705207uL, "PART"),
			Dependency.import(11182375243992395378uL, "PART"),
			Dependency.import(15628929445308478190uL, "PART")
		};
		dictionary[9880708269707785279uL] = new Dependency[0];
		dictionary[4000715797499115033uL] = new Dependency[0];
		dictionary[8628028762060951037uL] = new Dependency[0];
		dictionary[13216379475820520937uL] = new Dependency[6]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[2178802456762447785uL] = new Dependency[0];
		dictionary[3850246859562754413uL] = new Dependency[0];
		dictionary[12562573896413532156uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6893997975861880553uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR"),
			Dependency.import(17491181749064893977uL, "TXTR"),
			Dependency.import(17685539516547122665uL, "TXTR")
		};
		dictionary[14036551033045038249uL] = new Dependency[0];
		dictionary[7587447478059061330uL] = new Dependency[0];
		dictionary[1362393557420411429uL] = new Dependency[0];
		dictionary[6364072689069914177uL] = new Dependency[0];
		dictionary[15292116912001593738uL] = new Dependency[0];
		dictionary[7728753299762273302uL] = new Dependency[1] { Dependency.import(7485834586327012175uL, "TXTR") };
		dictionary[1303625010544438483uL] = new Dependency[0];
		dictionary[4137268101395742114uL] = new Dependency[0];
		dictionary[8551934603131446244uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(630393481592510399uL, "TXTR"),
			Dependency.import(2673351240663768305uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(13432154628010637490uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[17866468387280615187uL] = new Dependency[0];
		dictionary[9156196855062202139uL] = new Dependency[0];
		dictionary[2059797689186040252uL] = new Dependency[1] { Dependency.import(7485834586327012175uL, "TXTR") };
		dictionary[16081072595938795738uL] = new Dependency[0];
		dictionary[4750116281629688182uL] = new Dependency[0];
		dictionary[1416399779673537039uL] = new Dependency[0];
		dictionary[10024196604997912563uL] = new Dependency[0];
		dictionary[15612690161058074353uL] = new Dependency[0];
		dictionary[18207520845647290011uL] = new Dependency[9]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(1941599378631452943uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(4905017968892775931uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(14765632745460815128uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[9082657087262834231uL] = new Dependency[0];
		dictionary[2216802446791340033uL] = new Dependency[0];
		dictionary[9341600575215989082uL] = new Dependency[1] { Dependency.import(6890583768696084520uL, "TXTR") };
		dictionary[6991011420585764971uL] = new Dependency[5]
		{
			Dependency.import(5023657353008511577uL, "PART"),
			Dependency.import(5653135679476091416uL, "PART"),
			Dependency.import(12502169822229964968uL, "PART"),
			Dependency.import(13529564015562539782uL, "PART"),
			Dependency.import(13560186845490493298uL, "PART")
		};
		dictionary[10550689572253757517uL] = new Dependency[0];
		dictionary[5623185356551054190uL] = new Dependency[0];
		dictionary[11726552612436390738uL] = new Dependency[7]
		{
			Dependency.import(25289543644869298uL, "TXTR"),
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[13510436779201952792uL] = new Dependency[0];
		dictionary[15456319317506357623uL] = new Dependency[0];
		dictionary[3189994234944054442uL] = new Dependency[0];
		dictionary[12255338748243424809uL] = new Dependency[0];
		dictionary[17328790051365320892uL] = new Dependency[1] { Dependency.import(16238751108538286977uL, "TXTR") };
		dictionary[14872128411242869877uL] = new Dependency[0];
		dictionary[14004861904333728930uL] = new Dependency[5]
		{
			Dependency.import(6566445597276617130uL, "PART"),
			Dependency.import(7137525458123665287uL, "PART"),
			Dependency.import(13274383639286202300uL, "PART"),
			Dependency.import(13850991535460631316uL, "PART"),
			Dependency.import(13880591705516972286uL, "PART")
		};
		dictionary[3777351512367687559uL] = new Dependency[0];
		dictionary[8565354598124945382uL] = new Dependency[0];
		dictionary[15715050417915105304uL] = new Dependency[7]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(5684161697306486034uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR")
		};
		dictionary[17418969963892099647uL] = new Dependency[0];
		dictionary[11686398402952667579uL] = new Dependency[0];
		dictionary[11322130734825997024uL] = new Dependency[0];
		dictionary[17437271824696891448uL] = new Dependency[0];
		dictionary[17162883210240030991uL] = new Dependency[1] { Dependency.import(16238751108538286977uL, "TXTR") };
		dictionary[1711217606726147724uL] = new Dependency[1] { Dependency.import(15679385690788679838uL, "TXTR") };
		dictionary[6676219563211487173uL] = new Dependency[1] { Dependency.import(15679385690788679838uL, "TXTR") };
		dictionary[13786906413319162029uL] = new Dependency[0];
		dictionary[8781870449421268817uL] = new Dependency[20]
		{
			Dependency.import(297381736347806104uL, "TXTR"),
			Dependency.import(1366596482873901474uL, "TXTR"),
			Dependency.import(1423849603490678902uL, "TXTR"),
			Dependency.import(3227024819207168511uL, "TXTR"),
			Dependency.import(3865010957015369388uL, "TXTR"),
			Dependency.import(4623210170165220070uL, "TXTR"),
			Dependency.import(5684161697306486034uL, "TXTR"),
			Dependency.import(6831485495704885852uL, "TXTR"),
			Dependency.import(6924694992144286574uL, "TXTR"),
			Dependency.import(7092616580311672322uL, "TXTR"),
			Dependency.import(7328965053795114852uL, "TXTR"),
			Dependency.import(8094943435699173376uL, "TXTR"),
			Dependency.import(8410027965685754383uL, "TXTR"),
			Dependency.import(15380771469234194988uL, "TXTR"),
			Dependency.import(16264489293619408488uL, "TXTR"),
			Dependency.import(16495754193156511048uL, "TXTR"),
			Dependency.import(4015124079987390152uL, "TXTR"),
			Dependency.import(15622127147322245263uL, "TXTR"),
			Dependency.import(12166129107566771715uL, "TXTR"),
			Dependency.import(17195671189039121193uL, "TXTR")
		};
		dictionary[15970367179005898360uL] = new Dependency[0];
		dictionary[17187453754893088101uL] = new Dependency[0];
		dictionary[17173069180456239198uL] = new Dependency[0];
		dictionary[14294579797773761448uL] = new Dependency[0];
		dictionary[4029109053143620124uL] = new Dependency[1] { Dependency.import(16548723040388838987uL, "TXTR") };
		dictionary[12231246145000234322uL] = new Dependency[0];
		dictionary[14785641002583583802uL] = new Dependency[0];
		dictionary[3992291768341420288uL] = new Dependency[0];
		dictionary[426468189646273827uL] = new Dependency[0];
		dictionary[916541053714299711uL] = new Dependency[0];
		dictionary[1367859465012113706uL] = new Dependency[0];
		dictionary[1526862528106763475uL] = new Dependency[0];
		dictionary[16077859690526271937uL] = new Dependency[0];
		dictionary[6369365994490099692uL] = new Dependency[0];
		dictionary[9273539126471894336uL] = new Dependency[0];
		dictionary[3587137238317476971uL] = new Dependency[0];
		dictionary[10342831389196881573uL] = new Dependency[0];
		dictionary[15482233503230157426uL] = new Dependency[0];
		dictionary[12490410757585127952uL] = new Dependency[0];
		dictionary[5826416173635500595uL] = new Dependency[0];
		dictionary[4993817561204883452uL] = new Dependency[1] { Dependency.import(17959015384562857689uL, "TXTR") };
		dictionary[11409674055898906546uL] = new Dependency[0];
		dictionary[5638686474237531170uL] = new Dependency[0];
		dictionary[6027681196154124096uL] = new Dependency[0];
		dictionary[11112573284177442094uL] = new Dependency[0];
		dictionary[1148588453071853667uL] = new Dependency[0];
		dictionary[4521321244001047955uL] = new Dependency[0];
		dictionary[10520951488014605151uL] = new Dependency[0];
		dictionary[11779171333706053077uL] = new Dependency[0];
		dictionary[14479419399884613012uL] = new Dependency[0];
		dictionary[6212921745494877931uL] = new Dependency[0];
		dictionary[4591936007374415792uL] = new Dependency[0];
		dictionary[13725179759385404928uL] = new Dependency[0];
		dictionary[16148999342324292150uL] = new Dependency[0];
		dictionary[14208680886519569230uL] = new Dependency[0];
		dictionary[7849392829122749750uL] = new Dependency[1] { Dependency.import(10896086626469018674uL, "TXTR") };
		dictionary[2960391167552239106uL] = new Dependency[0];
		dictionary[5461336859955469143uL] = new Dependency[1] { Dependency.import(9532267408580869512uL, "TXTR") };
		dictionary[14271013225668573728uL] = new Dependency[1] { Dependency.import(9532267408580869512uL, "TXTR") };
		dictionary[17487682849986754402uL] = new Dependency[1] { Dependency.import(4596573324344294710uL, "TXTR") };
		dictionary[10803712534093190762uL] = new Dependency[0];
		dictionary[9003196894612281792uL] = new Dependency[0];
		dictionary[42004163459470017uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[15015147463261568946uL] = new Dependency[1] { Dependency.import(9003196894612281792uL, "TXTR") };
		dictionary[15268439100179651933uL] = new Dependency[2]
		{
			Dependency.import(853777400015996198uL, "CMDL"),
			Dependency.import(2960391167552239106uL, "TXTR")
		};
		dictionary[17644497126251177151uL] = new Dependency[1] { Dependency.import(9003196894612281792uL, "TXTR") };
		dictionary[16315094747931539764uL] = new Dependency[0];
		dictionary[789620340993680665uL] = new Dependency[1] { Dependency.import(16498892038684460011uL, "TXTR") };
		dictionary[16498892038684460011uL] = new Dependency[0];
		dictionary[7262126989566451347uL] = new Dependency[0];
		dictionary[10188840227710188653uL] = new Dependency[0];
		dictionary[1520420442143038911uL] = new Dependency[1] { Dependency.import(10436227703337796794uL, "TXTR") };
		dictionary[10436227703337796794uL] = new Dependency[0];
		dictionary[630393481592510399uL] = new Dependency[0];
		dictionary[10043071345413407226uL] = new Dependency[0];
		dictionary[13432154628010637490uL] = new Dependency[0];
		dictionary[2571297758885023326uL] = new Dependency[0];
		dictionary[7194714416708734120uL] = new Dependency[0];
		dictionary[1753372928331652130uL] = new Dependency[0];
		dictionary[2966682990408583370uL] = new Dependency[0];
		dictionary[8761175084044499119uL] = new Dependency[0];
		dictionary[10037187538736634909uL] = new Dependency[0];
		dictionary[15401599445244434244uL] = new Dependency[0];
		dictionary[1846963830496455397uL] = new Dependency[1] { Dependency.import(15945291006930524239uL, "TXTR") };
		dictionary[4540327826191764659uL] = new Dependency[0];
		dictionary[7021745000469995088uL] = new Dependency[0];
		dictionary[14765731490896820223uL] = new Dependency[0];
		dictionary[1941599378631452943uL] = new Dependency[0];
		dictionary[4905017968892775931uL] = new Dependency[0];
		dictionary[13649133105140475653uL] = new Dependency[0];
		dictionary[14765632745460815128uL] = new Dependency[0];
		dictionary[6796334216188807626uL] = new Dependency[1] { Dependency.import(14785641002583583802uL, "TXTR") };
		dictionary[2994560928401112936uL] = new Dependency[1] { Dependency.import(12105962298819664597uL, "TXTR") };
		dictionary[6294621317328383029uL] = new Dependency[2]
		{
			Dependency.import(7198140850108626481uL, "TXTR"),
			Dependency.import(12757873763578395588uL, "TXTR")
		};
		dictionary[7376337380674920252uL] = new Dependency[1] { Dependency.import(12105962298819664597uL, "TXTR") };
		dictionary[10649367674338706376uL] = new Dependency[0];
		dictionary[2910547187509282632uL] = new Dependency[0];
		dictionary[6077173232983826027uL] = new Dependency[0];
		dictionary[6363351949113548418uL] = new Dependency[0];
		dictionary[7897313984779302724uL] = new Dependency[0];
		dictionary[14329783064598644021uL] = new Dependency[0];
		dictionary[14769074767759382748uL] = new Dependency[0];
		dictionary[16863456863476071871uL] = new Dependency[0];
		dictionary[17448131538863483558uL] = new Dependency[0];
		dictionary[12122950288832508460uL] = new Dependency[0];
		dictionary[9324378830559852728uL] = new Dependency[0];
		dictionary[13035985192652736893uL] = new Dependency[0];
		dictionary[15679385690788679838uL] = new Dependency[0];
		dictionary[1423849603490678902uL] = new Dependency[0];
		dictionary[6831485495704885852uL] = new Dependency[0];
		dictionary[7328965053795114852uL] = new Dependency[0];
		dictionary[8094943435699173376uL] = new Dependency[0];
		dictionary[16660306179454351710uL] = new Dependency[3]
		{
			Dependency.import(3042119755723076793uL, "TXTR"),
			Dependency.import(6842713676913497667uL, "TXTR"),
			Dependency.import(7389617915147675672uL, "TXTR")
		};
		dictionary[7638577061319612875uL] = new Dependency[0];
		dictionary[1366596482873901474uL] = new Dependency[0];
		dictionary[3227024819207168511uL] = new Dependency[0];
		dictionary[3865010957015369388uL] = new Dependency[0];
		dictionary[4623210170165220070uL] = new Dependency[0];
		dictionary[5684161697306486034uL] = new Dependency[0];
		dictionary[6788018768710113278uL] = new Dependency[0];
		dictionary[7092616580311672322uL] = new Dependency[0];
		dictionary[8410027965685754383uL] = new Dependency[0];
		dictionary[15380771469234194988uL] = new Dependency[0];
		dictionary[16495754193156511048uL] = new Dependency[0];
		dictionary[4015124079987390152uL] = new Dependency[0];
		dictionary[12166129107566771715uL] = new Dependency[0];
		dictionary[17195671189039121193uL] = new Dependency[0];
		dictionary[7372782559495705207uL] = new Dependency[1] { Dependency.import(9453761016674001528uL, "TXTR") };
		dictionary[11182375243992395378uL] = new Dependency[1] { Dependency.import(6158154739140008556uL, "TXTR") };
		dictionary[15628929445308478190uL] = new Dependency[1] { Dependency.import(9453761016674001528uL, "TXTR") };
		dictionary[6893997975861880553uL] = new Dependency[0];
		dictionary[17491181749064893977uL] = new Dependency[0];
		dictionary[17685539516547122665uL] = new Dependency[0];
		dictionary[2673351240663768305uL] = new Dependency[0];
		dictionary[5023657353008511577uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[5653135679476091416uL] = new Dependency[1] { Dependency.import(17587897364755921316uL, "TXTR") };
		dictionary[12502169822229964968uL] = new Dependency[0];
		dictionary[13529564015562539782uL] = new Dependency[1] { Dependency.import(17587897364755921316uL, "TXTR") };
		dictionary[13560186845490493298uL] = new Dependency[1] { Dependency.import(10896086626469018674uL, "TXTR") };
		dictionary[25289543644869298uL] = new Dependency[0];
		dictionary[6566445597276617130uL] = new Dependency[1] { Dependency.import(10896086626469018674uL, "TXTR") };
		dictionary[7137525458123665287uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[13274383639286202300uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[13850991535460631316uL] = new Dependency[1] { Dependency.import(2960391167552239106uL, "TXTR") };
		dictionary[13880591705516972286uL] = new Dependency[1] { Dependency.import(8286051387533746394uL, "TXTR") };
		dictionary[15622127147322245263uL] = new Dependency[0];
		dictionary[17959015384562857689uL] = new Dependency[0];
		dictionary[10896086626469018674uL] = new Dependency[0];
		dictionary[9532267408580869512uL] = new Dependency[0];
		dictionary[4596573324344294710uL] = new Dependency[0];
		dictionary[853777400015996198uL] = new Dependency[1] { Dependency.import(6781549970314066141uL, "TXTR") };
		dictionary[15945291006930524239uL] = new Dependency[0];
		dictionary[12105962298819664597uL] = new Dependency[0];
		dictionary[7198140850108626481uL] = new Dependency[0];
		dictionary[12757873763578395588uL] = new Dependency[0];
		dictionary[9453761016674001528uL] = new Dependency[0];
		dictionary[6158154739140008556uL] = new Dependency[0];
		dictionary[17587897364755921316uL] = new Dependency[0];
		dictionary[8286051387533746394uL] = new Dependency[0];
		dictionary[6781549970314066141uL] = new Dependency[0];
		dictionary[1350220185162408166uL] = new Dependency[3]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(15495504509685829813uL, "TXTR"),
			Dependency.import(1034302964401698880uL, "STRG")
		};
		dictionary[15495504509685829813uL] = new Dependency[0];
		dictionary[1034302964401698880uL] = new Dependency[0];
		dictionary[965261587873123699uL] = new Dependency[0];
		dictionary[3598118067865727192uL] = new Dependency[6]
		{
			Dependency.import(5118879543974002307uL, "TXTR"),
			Dependency.import(9158124998498679599uL, "TXTR"),
			Dependency.import(11030168706918456865uL, "TXTR"),
			Dependency.import(15690119304663923424uL, "TXTR"),
			Dependency.import(12281885217947813602uL, "TXTR"),
			Dependency.import(12447842861673330137uL, "TXTR")
		};
		dictionary[5118879543974002307uL] = new Dependency[0];
		dictionary[9158124998498679599uL] = new Dependency[0];
		dictionary[11030168706918456865uL] = new Dependency[0];
		dictionary[15690119304663923424uL] = new Dependency[0];
		dictionary[12281885217947813602uL] = new Dependency[0];
		dictionary[12447842861673330137uL] = new Dependency[0];
		dictionary[3875719672297017933uL] = new Dependency[3]
		{
			Dependency.import(4678346738445068067uL, "TXTR"),
			Dependency.import(14446998785760144069uL, "CMDL"),
			Dependency.import(7035465571274258152uL, "STRG")
		};
		dictionary[4678346738445068067uL] = new Dependency[0];
		dictionary[14446998785760144069uL] = new Dependency[1] { Dependency.import(12231246145000234322uL, "TXTR") };
		dictionary[7035465571274258152uL] = new Dependency[0];
		dictionary[12510280824551341827uL] = new Dependency[2]
		{
			Dependency.import(16238751108538286977uL, "TXTR"),
			Dependency.import(7485834586327012175uL, "TXTR")
		};
		dictionary[518191066736303415uL] = new Dependency[4]
		{
			Dependency.import(12652616393146428157uL, "CMDL"),
			Dependency.import(2059797689186040252uL, "STRG"),
			Dependency.import(18311456839351366342uL, "CHAR"),
			Dependency.import(16081072595938795738uL, "TXTR")
		};
		dictionary[18311456839351366342uL] = new Dependency[10]
		{
			Dependency.import(5381175866485590705uL, "ELSC"),
			Dependency.import(14243671610499847398uL, "PART"),
			Dependency.import(1303625010544438483uL, "CSKR"),
			Dependency.import(4137268101395742114uL, "CINF"),
			Dependency.import(8551934603131446244uL, "CMDL"),
			Dependency.import(17866468387280615187uL, "SAND"),
			Dependency.import(18331912350379345361uL, "ELSC"),
			Dependency.import(624120757386143078uL, "CAUD"),
			Dependency.import(4973839121091639151uL, "ANIM"),
			Dependency.import(9156196855062202139uL, "ANIM")
		};
		dictionary[4430358168640447764uL] = new Dependency[0];
		dictionary[143789482513228031uL] = new Dependency[0];
		dictionary[17947759518887694835uL] = new Dependency[1] { Dependency.import(14872128411242869877uL, "TXTR") };
		dictionary[13605690565939857349uL] = new Dependency[0];
		dictionary[12379739850550345728uL] = new Dependency[0];
		dictionary[12379739850550345729uL] = new Dependency[0];
		dictionary[12379739850550345730uL] = new Dependency[0];
		dictionary[12379739850550345731uL] = new Dependency[0];
		dictionary[12379739850550345732uL] = new Dependency[0];
		dictionary[12379739850550345733uL] = new Dependency[0];
		dictionary[12379739850550345734uL] = new Dependency[0];
		dictionary[12379739850550345735uL] = new Dependency[0];
		dictionary[12379739850550345736uL] = new Dependency[0];
		dictionary[12379739850550345737uL] = new Dependency[0];
		dictionary[520877543450287337uL] = new Dependency[1] { Dependency.import(16736787680862962376uL, "TXTR") };
		dictionary[16736787680862962376uL] = new Dependency[0];
		dictionary[5047729426257305854uL] = new Dependency[1] { Dependency.import(2116349832385564692uL, "TXTR") };
		dictionary[2116349832385564692uL] = new Dependency[0];
		List<ulong> list = new List<ulong>();
		foreach (ulong key in dictionary.Keys)
		{
			Dependency[] array = dictionary[key];
			foreach (Dependency dependency in array)
			{
				if (!dictionary.ContainsKey(dependency.file_id) && !list.Contains(dependency.file_id))
				{
					Console.WriteLine("Dependency data is missing for 0x" + dependency.file_id.ToString("X8"));
					list.Add(dependency.file_id);
				}
			}
		}
		return dictionary;
	}

	public static void add_unique_dependencies(List<Dependency> dependency_list, List<Dependency> dependencies_to_add)
	{
		List<ulong> list = new List<ulong>();
		foreach (Dependency item in dependency_list)
		{
			list.Add(item.file_id);
		}
		foreach (Dependency item2 in dependencies_to_add)
		{
			if (!list.Contains(item2.file_id))
			{
				list.Add(item2.file_id);
				dependency_list.Add(item2);
			}
		}
	}

	public static List<Dependency> get_dependencies_of(Dictionary<ulong, Dependency[]> file_dependencies, ulong resource_id, string resource_type)
	{
		int i = 0;
		List<Dependency> list = new List<Dependency>();
		list.Add(Dependency.import(resource_id, resource_type));
		List<ulong> list2 = new List<ulong>();
		list2.Add(resource_id);
		for (; i != list.Count; i++)
		{
			if (!file_dependencies.ContainsKey(list[i].file_id))
			{
				throw new KeyNotFoundException("Dependency list not found for resource ID: " + list[i].file_id);
			}
			Dependency[] array = file_dependencies[list[i].file_id];
			foreach (Dependency dependency in array)
			{
				if (!list2.Contains(dependency.file_id))
				{
					list2.Add(dependency.file_id);
					list.Add(dependency);
				}
			}
		}
		return list;
	}

	public static List<Dependency> order_dependencies(Dictionary<ulong, Dependency[]> file_dependencies, List<Dependency> dependency_list)
	{
		List<Dependency> list = new List<Dependency>();
		uint num = 0u;
		HashSet<ulong> hashSet = new HashSet<ulong>();
		while (list.Count != dependency_list.Count || num == 100)
		{
			num++;
			foreach (Dependency item in dependency_list)
			{
				if (hashSet.Contains(item.file_id))
				{
					continue;
				}
				List<Dependency> list2 = get_dependencies_of(file_dependencies, item.file_id, Encoding.UTF8.GetString(item.resource_type));
				bool flag = true;
				foreach (Dependency item2 in list2)
				{
					if (!hashSet.Contains(item2.file_id) && item2.file_id != item.file_id)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(item);
					hashSet.Add(item.file_id);
				}
			}
		}
		return list;
	}
}
