using Domain.Entities.Countries;

namespace Data.Mock.Countries
{
	internal static class CountrySource
	{
		public static readonly Country[] Data =
		[
			new Country(
				Id: Guid.NewGuid(),
				Name: "United Arab Emirates",
				Iso2Code: "AE",
				PhoneNumberCode: "+971",
				FlagImageUrl: "https://flagcdn.com/32x24/ae.png",
				PhoneNumberMasks: ["5-##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Afghanistan",
				Iso2Code: "AF",
				PhoneNumberCode: "+93",
				FlagImageUrl: "https://flagcdn.com/32x24/af.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Aland Islands",
				Iso2Code: "AX",
				PhoneNumberCode: "+358",
				FlagImageUrl: "https://flagcdn.com/32x24/ax.png",
				PhoneNumberMasks: ["(###)###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Albania",
				Iso2Code: "AL",
				PhoneNumberCode: "+355",
				FlagImageUrl: "https://flagcdn.com/32x24/al.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Algeria",
				Iso2Code: "DZ",
				PhoneNumberCode: "+213",
				FlagImageUrl: "https://flagcdn.com/32x24/dz.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "American Samoa",
				Iso2Code: "AS",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/as.png",
				PhoneNumberMasks: ["(684)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Andorra",
				Iso2Code: "AD",
				PhoneNumberCode: "+376",
				FlagImageUrl: "https://flagcdn.com/32x24/ad.png",
				PhoneNumberMasks: ["###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Angola",
				Iso2Code: "AO",
				PhoneNumberCode: "+244",
				FlagImageUrl: "https://flagcdn.com/32x24/ao.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Anguilla",
				Iso2Code: "AI",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/ai.png",
				PhoneNumberMasks: ["(224)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Antarctica",
				Iso2Code: "AQ",
				PhoneNumberCode: "+672",
				FlagImageUrl: "https://flagcdn.com/32x24/aq.png",
				PhoneNumberMasks: ["1##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Antigua and Barbuda",
				Iso2Code: "AG",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/ag.png",
				PhoneNumberMasks: ["(268)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Argentina",
				Iso2Code: "AR",
				PhoneNumberCode: "+54",
				FlagImageUrl: "https://flagcdn.com/32x24/ar.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Armenia",
				Iso2Code: "AM",
				PhoneNumberCode: "+374",
				FlagImageUrl: "https://flagcdn.com/32x24/am.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Aruba",
				Iso2Code: "AW",
				PhoneNumberCode: "+297",
				FlagImageUrl: "https://flagcdn.com/32x24/aw.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ascension Island",
				Iso2Code: "AC",
				PhoneNumberCode: "+247",
				FlagImageUrl: "https://flagcdn.com/32x24/sh.png",
				PhoneNumberMasks: ["####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Australia",
				Iso2Code: "AU",
				PhoneNumberCode: "+61",
				FlagImageUrl: "https://flagcdn.com/32x24/au.png",
				PhoneNumberMasks: ["#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Austria",
				Iso2Code: "AT",
				PhoneNumberCode: "+43",
				FlagImageUrl: "https://flagcdn.com/32x24/at.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Azerbaijan",
				Iso2Code: "AZ",
				PhoneNumberCode: "+994",
				FlagImageUrl: "https://flagcdn.com/32x24/az.png",
				PhoneNumberMasks: ["##-###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bahamas",
				Iso2Code: "BS",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/bs.png",
				PhoneNumberMasks: ["(242)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bahrain",
				Iso2Code: "BH",
				PhoneNumberCode: "+973",
				FlagImageUrl: "https://flagcdn.com/32x24/bh.png",
				PhoneNumberMasks:
				[
					"31-###-###",
					"322-#-##-##",
					"383-#-##-##",
					"384-#-##-##",
					"388-#-##-##",
					"39-###-###",
					"377-#-##-##",
					"36-###-###",
					"345-#-##-##",
					"344-#-##-##",
					"343-#-##-##",
					"341-#-##-##",
					"340-#-##-##",
					"33-###-###"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bangladesh",
				Iso2Code: "BD",
				PhoneNumberCode: "+880",
				FlagImageUrl: "https://flagcdn.com/32x24/bd.png",
				PhoneNumberMasks: ["1###-######"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Barbados",
				Iso2Code: "BB",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/bb.png",
				PhoneNumberMasks: ["(246)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Belarus",
				Iso2Code: "BY",
				PhoneNumberCode: "+375",
				FlagImageUrl: "https://flagcdn.com/32x24/by.png",
				PhoneNumberMasks: ["(##)###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Belgium",
				Iso2Code: "BE",
				PhoneNumberCode: "+32",
				FlagImageUrl: "https://flagcdn.com/32x24/be.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Belize",
				Iso2Code: "BZ",
				PhoneNumberCode: "+501",
				FlagImageUrl: "https://flagcdn.com/32x24/bz.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Benin",
				Iso2Code: "BJ",
				PhoneNumberCode: "+229",
				FlagImageUrl: "https://flagcdn.com/32x24/bj.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bermuda",
				Iso2Code: "BM",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/bm.png",
				PhoneNumberMasks: ["(441)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bhutan",
				Iso2Code: "BT",
				PhoneNumberCode: "+975",
				FlagImageUrl: "https://flagcdn.com/32x24/bt.png",
				PhoneNumberMasks: ["17-###-###", "#-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bolivia",
				Iso2Code: "BO",
				PhoneNumberCode: "+591",
				FlagImageUrl: "https://flagcdn.com/32x24/bo.png",
				PhoneNumberMasks: ["#-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bosnia and Herzegovina",
				Iso2Code: "BA",
				PhoneNumberCode: "+387",
				FlagImageUrl: "https://flagcdn.com/32x24/ba.png",
				PhoneNumberMasks: ["##-####", "##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Botswana",
				Iso2Code: "BW",
				PhoneNumberCode: "+267",
				FlagImageUrl: "https://flagcdn.com/32x24/bw.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Brazil",
				Iso2Code: "BR",
				PhoneNumberCode: "+55",
				FlagImageUrl: "https://flagcdn.com/32x24/br.png",
				PhoneNumberMasks: ["(##)####-####", "(##)#####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "British Indian Ocean Territory",
				Iso2Code: "IO",
				PhoneNumberCode: "+246",
				FlagImageUrl: "https://flagcdn.com/32x24/io.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Brunei Darussalam",
				Iso2Code: "BN",
				PhoneNumberCode: "+673",
				FlagImageUrl: "https://flagcdn.com/32x24/bn.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Bulgaria",
				Iso2Code: "BG",
				PhoneNumberCode: "+359",
				FlagImageUrl: "https://flagcdn.com/32x24/bg.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Burkina Faso",
				Iso2Code: "BF",
				PhoneNumberCode: "+226",
				FlagImageUrl: "https://flagcdn.com/32x24/bf.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Burundi",
				Iso2Code: "BI",
				PhoneNumberCode: "+257",
				FlagImageUrl: "https://flagcdn.com/32x24/bi.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cambodia",
				Iso2Code: "KH",
				PhoneNumberCode: "+855",
				FlagImageUrl: "https://flagcdn.com/32x24/kh.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cameroon",
				Iso2Code: "CM",
				PhoneNumberCode: "+237",
				FlagImageUrl: "https://flagcdn.com/32x24/cm.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Canada",
				Iso2Code: "CA",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/ca.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cape Verde",
				Iso2Code: "CV",
				PhoneNumberCode: "+238",
				FlagImageUrl: "https://flagcdn.com/32x24/cv.png",
				PhoneNumberMasks: ["(###)##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cayman Islands",
				Iso2Code: "KY",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/ky.png",
				PhoneNumberMasks: ["(345)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Central African Republic",
				Iso2Code: "CF",
				PhoneNumberCode: "+236",
				FlagImageUrl: "https://flagcdn.com/32x24/cf.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Chad",
				Iso2Code: "TD",
				PhoneNumberCode: "+235",
				FlagImageUrl: "https://flagcdn.com/32x24/td.png",
				PhoneNumberMasks: ["##-##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Chile",
				Iso2Code: "CL",
				PhoneNumberCode: "+56",
				FlagImageUrl: "https://flagcdn.com/32x24/cl.png",
				PhoneNumberMasks: ["#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "China",
				Iso2Code: "CN",
				PhoneNumberCode: "+86",
				FlagImageUrl: "https://flagcdn.com/32x24/cn.png",
				PhoneNumberMasks: ["(###)####-###", "(###)####-####", "##-#####-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Christmas Island",
				Iso2Code: "CX",
				PhoneNumberCode: "+61",
				FlagImageUrl: "https://flagcdn.com/32x24/cx.png",
				PhoneNumberMasks: ["#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cocos (Keeling) Islands",
				Iso2Code: "CC",
				PhoneNumberCode: "+61",
				FlagImageUrl: "https://flagcdn.com/32x24/cc.png",
				PhoneNumberMasks: ["#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Colombia",
				Iso2Code: "CO",
				PhoneNumberCode: "+57",
				FlagImageUrl: "https://flagcdn.com/32x24/co.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Comoros",
				Iso2Code: "KM",
				PhoneNumberCode: "+269",
				FlagImageUrl: "https://flagcdn.com/32x24/km.png",
				PhoneNumberMasks: ["##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Congo",
				Iso2Code: "CG",
				PhoneNumberCode: "+242",
				FlagImageUrl: "https://flagcdn.com/32x24/cg.png",
				PhoneNumberMasks: ["##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cook Islands",
				Iso2Code: "CK",
				PhoneNumberCode: "+682",
				FlagImageUrl: "https://flagcdn.com/32x24/ck.png",
				PhoneNumberMasks: ["##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Costa Rica",
				Iso2Code: "CR",
				PhoneNumberCode: "+506",
				FlagImageUrl: "https://flagcdn.com/32x24/cr.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Croatia",
				Iso2Code: "HR",
				PhoneNumberCode: "+385",
				FlagImageUrl: "https://flagcdn.com/32x24/hr.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cuba",
				Iso2Code: "CU",
				PhoneNumberCode: "+53",
				FlagImageUrl: "https://flagcdn.com/32x24/cu.png",
				PhoneNumberMasks: ["#-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Cyprus",
				Iso2Code: "CY",
				PhoneNumberCode: "+357",
				FlagImageUrl: "https://flagcdn.com/32x24/cy.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Czech Republic",
				Iso2Code: "CZ",
				PhoneNumberCode: "+420",
				FlagImageUrl: "https://flagcdn.com/32x24/cz.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Democratic Republic of the Congo",
				Iso2Code: "CD",
				PhoneNumberCode: "+243",
				FlagImageUrl: "https://flagcdn.com/32x24/cd.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Denmark",
				Iso2Code: "DK",
				PhoneNumberCode: "+45",
				FlagImageUrl: "https://flagcdn.com/32x24/dk.png",
				PhoneNumberMasks: ["##-##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Djibouti",
				Iso2Code: "DJ",
				PhoneNumberCode: "+253",
				FlagImageUrl: "https://flagcdn.com/32x24/dj.png",
				PhoneNumberMasks: ["##-##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Dominica",
				Iso2Code: "DM",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/dm.png",
				PhoneNumberMasks: ["(767)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Dominican Republic",
				Iso2Code: "DO",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/do.png",
				PhoneNumberMasks: ["(809)###-####", "(829)###-####", "(849)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ecuador",
				Iso2Code: "EC",
				PhoneNumberCode: "+593",
				FlagImageUrl: "https://flagcdn.com/32x24/ec.png",
				PhoneNumberMasks: ["#-###-####", "##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Egypt",
				Iso2Code: "EG",
				PhoneNumberCode: "+20",
				FlagImageUrl: "https://flagcdn.com/32x24/eg.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "El Salvador",
				Iso2Code: "SV",
				PhoneNumberCode: "+503",
				FlagImageUrl: "https://flagcdn.com/32x24/sv.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Equatorial Guinea",
				Iso2Code: "GQ",
				PhoneNumberCode: "+240",
				FlagImageUrl: "https://flagcdn.com/32x24/gq.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Eritrea",
				Iso2Code: "ER",
				PhoneNumberCode: "+291",
				FlagImageUrl: "https://flagcdn.com/32x24/er.png",
				PhoneNumberMasks: ["#-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Estonia",
				Iso2Code: "EE",
				PhoneNumberCode: "+372",
				FlagImageUrl: "https://flagcdn.com/32x24/ee.png",
				PhoneNumberMasks: ["###-####", "####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Eswatini",
				Iso2Code: "SZ",
				PhoneNumberCode: "+268",
				FlagImageUrl: "https://flagcdn.com/32x24/sz.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ethiopia",
				Iso2Code: "ET",
				PhoneNumberCode: "+251",
				FlagImageUrl: "https://flagcdn.com/32x24/et.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Falkland Islands (Malvinas)",
				Iso2Code: "FK",
				PhoneNumberCode: "+500",
				FlagImageUrl: "https://flagcdn.com/32x24/fk.png",
				PhoneNumberMasks: ["#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Faroe Islands",
				Iso2Code: "FO",
				PhoneNumberCode: "+298",
				FlagImageUrl: "https://flagcdn.com/32x24/fo.png",
				PhoneNumberMasks: ["###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Fiji",
				Iso2Code: "FJ",
				PhoneNumberCode: "+679",
				FlagImageUrl: "https://flagcdn.com/32x24/fj.png",
				PhoneNumberMasks: ["##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Finland",
				Iso2Code: "FI",
				PhoneNumberCode: "+358",
				FlagImageUrl: "https://flagcdn.com/32x24/fi.png",
				PhoneNumberMasks: ["(###)###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "France",
				Iso2Code: "FR",
				PhoneNumberCode: "+33",
				FlagImageUrl: "https://flagcdn.com/32x24/fr.png",
				PhoneNumberMasks: ["# ## ## ## ##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "French Guiana",
				Iso2Code: "GF",
				PhoneNumberCode: "+594",
				FlagImageUrl: "https://flagcdn.com/32x24/gf.png",
				PhoneNumberMasks: ["#####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "French Polynesia",
				Iso2Code: "PF",
				PhoneNumberCode: "+689",
				FlagImageUrl: "https://flagcdn.com/32x24/pf.png",
				PhoneNumberMasks: ["##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Gabon",
				Iso2Code: "GA",
				PhoneNumberCode: "+241",
				FlagImageUrl: "https://flagcdn.com/32x24/ga.png",
				PhoneNumberMasks: ["#-##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Gambia",
				Iso2Code: "GM",
				PhoneNumberCode: "+220",
				FlagImageUrl: "https://flagcdn.com/32x24/gm.png",
				PhoneNumberMasks: ["(###)##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Georgia",
				Iso2Code: "GE",
				PhoneNumberCode: "+995",
				FlagImageUrl: "https://flagcdn.com/32x24/ge.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Germany",
				Iso2Code: "DE",
				PhoneNumberCode: "+49",
				FlagImageUrl: "https://flagcdn.com/32x24/de.png",
				PhoneNumberMasks:
				[
					"###-###",
					"(###)##-##",
					"(###)##-###",
					"(###)##-####",
					"(###)###-####",
					"(####)###-####"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ghana",
				Iso2Code: "GH",
				PhoneNumberCode: "+233",
				FlagImageUrl: "https://flagcdn.com/32x24/gh.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Gibraltar",
				Iso2Code: "GI",
				PhoneNumberCode: "+350",
				FlagImageUrl: "https://flagcdn.com/32x24/gi.png",
				PhoneNumberMasks: ["###-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Greece",
				Iso2Code: "GR",
				PhoneNumberCode: "+30",
				FlagImageUrl: "https://flagcdn.com/32x24/gr.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Greenland",
				Iso2Code: "GL",
				PhoneNumberCode: "+299",
				FlagImageUrl: "https://flagcdn.com/32x24/gl.png",
				PhoneNumberMasks: ["##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Grenada",
				Iso2Code: "GD",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/gd.png",
				PhoneNumberMasks: ["(473)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guadeloupe",
				Iso2Code: "GP",
				PhoneNumberCode: "+590",
				FlagImageUrl: "https://flagcdn.com/32x24/gp.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guam",
				Iso2Code: "GU",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/gu.png",
				PhoneNumberMasks: ["(671)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guatemala",
				Iso2Code: "GT",
				PhoneNumberCode: "+502",
				FlagImageUrl: "https://flagcdn.com/32x24/gt.png",
				PhoneNumberMasks: ["#-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guernsey",
				Iso2Code: "GG",
				PhoneNumberCode: "+44",
				FlagImageUrl: "https://flagcdn.com/32x24/gg.png",
				PhoneNumberMasks: ["##-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guinea",
				Iso2Code: "GN",
				PhoneNumberCode: "+224",
				FlagImageUrl: "https://flagcdn.com/32x24/gn.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guinea-Bissau",
				Iso2Code: "GW",
				PhoneNumberCode: "+245",
				FlagImageUrl: "https://flagcdn.com/32x24/gw.png",
				PhoneNumberMasks: ["#-######"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Guyana",
				Iso2Code: "GY",
				PhoneNumberCode: "+592",
				FlagImageUrl: "https://flagcdn.com/32x24/gy.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Haiti",
				Iso2Code: "HT",
				PhoneNumberCode: "+509",
				FlagImageUrl: "https://flagcdn.com/32x24/ht.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Holy See (Vatican City State)",
				Iso2Code: "VA",
				PhoneNumberCode: "+39",
				FlagImageUrl: "https://flagcdn.com/32x24/va.png",
				PhoneNumberMasks: ["06 698#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Honduras",
				Iso2Code: "HN",
				PhoneNumberCode: "+504",
				FlagImageUrl: "https://flagcdn.com/32x24/hn.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Hong Kong",
				Iso2Code: "HK",
				PhoneNumberCode: "+852",
				FlagImageUrl: "https://flagcdn.com/32x24/hk.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Hungary",
				Iso2Code: "HU",
				PhoneNumberCode: "+36",
				FlagImageUrl: "https://flagcdn.com/32x24/hu.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Iceland",
				Iso2Code: "IS",
				PhoneNumberCode: "+354",
				FlagImageUrl: "https://flagcdn.com/32x24/is.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "India",
				Iso2Code: "IN",
				PhoneNumberCode: "+91",
				FlagImageUrl: "https://flagcdn.com/32x24/in.png",
				PhoneNumberMasks: ["(####)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Indonesia",
				Iso2Code: "ID",
				PhoneNumberCode: "+62",
				FlagImageUrl: "https://flagcdn.com/32x24/id.png",
				PhoneNumberMasks:
				[
					"##-###-##",
					"##-###-###",
					"##-###-####",
					"(8##)###-###",
					"(8##)###-##-###"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Iran",
				Iso2Code: "IR",
				PhoneNumberCode: "+98",
				FlagImageUrl: "https://flagcdn.com/32x24/ir.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Iraq",
				Iso2Code: "IQ",
				PhoneNumberCode: "+924",
				FlagImageUrl: "https://flagcdn.com/32x24/iq.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ireland",
				Iso2Code: "IE",
				PhoneNumberCode: "+353",
				FlagImageUrl: "https://flagcdn.com/32x24/ie.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Isle of Man",
				Iso2Code: "IM",
				PhoneNumberCode: "+44",
				FlagImageUrl: "https://flagcdn.com/32x24/im.png",
				PhoneNumberMasks: ["##-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Israel",
				Iso2Code: "IL",
				PhoneNumberCode: "+972",
				FlagImageUrl: "https://flagcdn.com/32x24/il.png",
				PhoneNumberMasks: ["#-###-####", "5#-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Italy",
				Iso2Code: "IT",
				PhoneNumberCode: "+39",
				FlagImageUrl: "https://flagcdn.com/32x24/it.png",
				PhoneNumberMasks: ["(###)####-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ivory Coast / Cote d'Ivoire",
				Iso2Code: "CI",
				PhoneNumberCode: "+225",
				FlagImageUrl: "https://flagcdn.com/32x24/ci.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Jamaica",
				Iso2Code: "JM",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/jm.png",
				PhoneNumberMasks: ["(876)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Japan",
				Iso2Code: "JP",
				PhoneNumberCode: "+81",
				FlagImageUrl: "https://flagcdn.com/32x24/jp.png",
				PhoneNumberMasks: ["(###)###-###", "##-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Jersey",
				Iso2Code: "JE",
				PhoneNumberCode: "+44",
				FlagImageUrl: "https://flagcdn.com/32x24/je.png",
				PhoneNumberMasks: ["##-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Jordan",
				Iso2Code: "JO",
				PhoneNumberCode: "+962",
				FlagImageUrl: "https://flagcdn.com/32x24/jo.png",
				PhoneNumberMasks: ["#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Kazakhstan",
				Iso2Code: "KZ",
				PhoneNumberCode: "+77",
				FlagImageUrl: "https://flagcdn.com/32x24/kz.png",
				PhoneNumberMasks: ["(6##)###-##-##", "(7##)###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Kenya",
				Iso2Code: "KE",
				PhoneNumberCode: "+254",
				FlagImageUrl: "https://flagcdn.com/32x24/ke.png",
				PhoneNumberMasks: ["###-######"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Kiribati",
				Iso2Code: "KI",
				PhoneNumberCode: "+686",
				FlagImageUrl: "https://flagcdn.com/32x24/ki.png",
				PhoneNumberMasks: ["##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Korea, Democratic People's Republic of Korea",
				Iso2Code: "KP",
				PhoneNumberCode: "+850",
				FlagImageUrl: "https://flagcdn.com/32x24/kp.png",
				PhoneNumberMasks:
				[
					"###-###",
					"####-####",
					"##-###-###",
					"###-####-###",
					"191-###-####",
					"####-#############"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Korea, Republic of South Korea",
				Iso2Code: "KR",
				PhoneNumberCode: "+82",
				FlagImageUrl: "https://flagcdn.com/32x24/kr.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Kosovo",
				Iso2Code: "XK",
				PhoneNumberCode: "+383",
				FlagImageUrl: "https://flagcdn.com/32x24/xk.png",
				PhoneNumberMasks: ["##-###-###", "###-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Kuwait",
				Iso2Code: "KW",
				PhoneNumberCode: "+965",
				FlagImageUrl: "https://flagcdn.com/32x24/kw.png",
				PhoneNumberMasks: ["41-###-###", "5-##-##-###", "6-##-##-###", "9-##-##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Kyrgyzstan",
				Iso2Code: "KG",
				PhoneNumberCode: "+996",
				FlagImageUrl: "https://flagcdn.com/32x24/kg.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Laos",
				Iso2Code: "LA",
				PhoneNumberCode: "+856",
				FlagImageUrl: "https://flagcdn.com/32x24/la.png",
				PhoneNumberMasks: ["##-###-###", "(20##)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Latvia",
				Iso2Code: "LV",
				PhoneNumberCode: "+371",
				FlagImageUrl: "https://flagcdn.com/32x24/lv.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Lebanon",
				Iso2Code: "LB",
				PhoneNumberCode: "+961",
				FlagImageUrl: "https://flagcdn.com/32x24/lb.png",
				PhoneNumberMasks: ["#-###-###", "##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Lesotho",
				Iso2Code: "LS",
				PhoneNumberCode: "+266",
				FlagImageUrl: "https://flagcdn.com/32x24/ls.png",
				PhoneNumberMasks: ["#-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Liberia",
				Iso2Code: "LR",
				PhoneNumberCode: "+231",
				FlagImageUrl: "https://flagcdn.com/32x24/lr.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Libya",
				Iso2Code: "LY",
				PhoneNumberCode: "+218",
				FlagImageUrl: "https://flagcdn.com/32x24/ly.png",
				PhoneNumberMasks: ["##-###-###", "21-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Liechtenstein",
				Iso2Code: "LI",
				PhoneNumberCode: "+423",
				FlagImageUrl: "https://flagcdn.com/32x24/li.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Lithuania",
				Iso2Code: "LT",
				PhoneNumberCode: "+370",
				FlagImageUrl: "https://flagcdn.com/32x24/lt.png",
				PhoneNumberMasks: ["(###)##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Luxembourg",
				Iso2Code: "LU",
				PhoneNumberCode: "+352",
				FlagImageUrl: "https://flagcdn.com/32x24/lu.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Macau",
				Iso2Code: "MO",
				PhoneNumberCode: "+853",
				FlagImageUrl: "https://flagcdn.com/32x24/mo.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Madagascar",
				Iso2Code: "MG",
				PhoneNumberCode: "+261",
				FlagImageUrl: "https://flagcdn.com/32x24/mg.png",
				PhoneNumberMasks: ["##-##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Malawi",
				Iso2Code: "MW",
				PhoneNumberCode: "+265",
				FlagImageUrl: "https://flagcdn.com/32x24/mw.png",
				PhoneNumberMasks: ["1-###-###", "#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Malaysia",
				Iso2Code: "MY",
				PhoneNumberCode: "+60",
				FlagImageUrl: "https://flagcdn.com/32x24/my.png",
				PhoneNumberMasks: ["#-###-###", "##-###-###", "(###)###-###", "##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Maldives",
				Iso2Code: "MV",
				PhoneNumberCode: "+960",
				FlagImageUrl: "https://flagcdn.com/32x24/mv.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mali",
				Iso2Code: "ML",
				PhoneNumberCode: "+223",
				FlagImageUrl: "https://flagcdn.com/32x24/ml.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Malta",
				Iso2Code: "MT",
				PhoneNumberCode: "+356",
				FlagImageUrl: "https://flagcdn.com/32x24/mt.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Marshall Islands",
				Iso2Code: "MH",
				PhoneNumberCode: "+692",
				FlagImageUrl: "https://flagcdn.com/32x24/mh.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Martinique",
				Iso2Code: "MQ",
				PhoneNumberCode: "+596",
				FlagImageUrl: "https://flagcdn.com/32x24/mq.png",
				PhoneNumberMasks: ["(###)##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mauritania",
				Iso2Code: "MR",
				PhoneNumberCode: "+222",
				FlagImageUrl: "https://flagcdn.com/32x24/mr.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mauritius",
				Iso2Code: "MU",
				PhoneNumberCode: "+230",
				FlagImageUrl: "https://flagcdn.com/32x24/mu.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mayotte",
				Iso2Code: "YT",
				PhoneNumberCode: "+262",
				FlagImageUrl: "https://flagcdn.com/32x24/yt.png",
				PhoneNumberMasks: ["#####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mexico",
				Iso2Code: "MX",
				PhoneNumberCode: "+52",
				FlagImageUrl: "https://flagcdn.com/32x24/mx.png",
				PhoneNumberMasks: ["##-##-####", "(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Micronesia, Federated States of Micronesia",
				Iso2Code: "FM",
				PhoneNumberCode: "+691",
				FlagImageUrl: "https://flagcdn.com/32x24/fm.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Moldova",
				Iso2Code: "MD",
				PhoneNumberCode: "+373",
				FlagImageUrl: "https://flagcdn.com/32x24/md.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Monaco",
				Iso2Code: "MC",
				PhoneNumberCode: "+377",
				FlagImageUrl: "https://flagcdn.com/32x24/mc.png",
				PhoneNumberMasks: ["##-###-###", "(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mongolia",
				Iso2Code: "MN",
				PhoneNumberCode: "+976",
				FlagImageUrl: "https://flagcdn.com/32x24/mn.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Montenegro",
				Iso2Code: "ME",
				PhoneNumberCode: "+382",
				FlagImageUrl: "https://flagcdn.com/32x24/me.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Montserrat",
				Iso2Code: "MS",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/ms.png",
				PhoneNumberMasks: ["(624)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Morocco",
				Iso2Code: "MA",
				PhoneNumberCode: "+212",
				FlagImageUrl: "https://flagcdn.com/32x24/ma.png",
				PhoneNumberMasks: ["##-####-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Mozambique",
				Iso2Code: "MZ",
				PhoneNumberCode: "+258",
				FlagImageUrl: "https://flagcdn.com/32x24/mz.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Myanmar",
				Iso2Code: "MM",
				PhoneNumberCode: "+95",
				FlagImageUrl: "https://flagcdn.com/32x24/mm.png",
				PhoneNumberMasks: ["###-###", "#-###-###", "##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Namibia",
				Iso2Code: "NA",
				PhoneNumberCode: "+224",
				FlagImageUrl: "https://flagcdn.com/32x24/na.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Nauru",
				Iso2Code: "NR",
				PhoneNumberCode: "+674",
				FlagImageUrl: "https://flagcdn.com/32x24/nr.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Nepal",
				Iso2Code: "NP",
				PhoneNumberCode: "+977",
				FlagImageUrl: "https://flagcdn.com/32x24/np.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Netherlands",
				Iso2Code: "NL",
				PhoneNumberCode: "+31",
				FlagImageUrl: "https://flagcdn.com/32x24/nl.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "New Caledonia",
				Iso2Code: "NC",
				PhoneNumberCode: "+687",
				FlagImageUrl: "https://flagcdn.com/32x24/nc.png",
				PhoneNumberMasks: ["##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "New Zealand",
				Iso2Code: "NZ",
				PhoneNumberCode: "+24",
				FlagImageUrl: "https://flagcdn.com/32x24/nz.png",
				PhoneNumberMasks: ["#-###-###", "(###)###-###", "(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Nicaragua",
				Iso2Code: "NI",
				PhoneNumberCode: "+505",
				FlagImageUrl: "https://flagcdn.com/32x24/ni.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Niger",
				Iso2Code: "NE",
				PhoneNumberCode: "+227",
				FlagImageUrl: "https://flagcdn.com/32x24/ne.png",
				PhoneNumberMasks: ["##-##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Nigeria",
				Iso2Code: "NG",
				PhoneNumberCode: "+234",
				FlagImageUrl: "https://flagcdn.com/32x24/ng.png",
				PhoneNumberMasks: ["##-###-##", "##-###-###", "(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Niue",
				Iso2Code: "NU",
				PhoneNumberCode: "+683",
				FlagImageUrl: "https://flagcdn.com/32x24/nu.png",
				PhoneNumberMasks: ["####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Norfolk Island",
				Iso2Code: "NF",
				PhoneNumberCode: "+672",
				FlagImageUrl: "https://flagcdn.com/32x24/nf.png",
				PhoneNumberMasks: ["3##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "North Macedonia",
				Iso2Code: "MK",
				PhoneNumberCode: "+389",
				FlagImageUrl: "https://flagcdn.com/32x24/mk.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Northern Mariana Islands",
				Iso2Code: "MP",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/mp.png",
				PhoneNumberMasks: ["(670)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Norway",
				Iso2Code: "NO",
				PhoneNumberCode: "+47",
				FlagImageUrl: "https://flagcdn.com/32x24/no.png",
				PhoneNumberMasks: ["(###)##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Oman",
				Iso2Code: "OM",
				PhoneNumberCode: "+968",
				FlagImageUrl: "https://flagcdn.com/32x24/om.png",
				PhoneNumberMasks:
				[
					"71##-##-##",
					"72##-##-##",
					"73##-##-##",
					"74##-##-##",
					"75##-##-##",
					"76##-##-##",
					"77##-##-##",
					"78##-##-##",
					"79##-##-##",
					"91##-##-##",
					"92##-##-##",
					"93##-##-##",
					"94##-##-##",
					"95##-##-##",
					"96##-##-##",
					"97##-##-##",
					"98##-##-##",
					"99##-##-##",
					"901#-##-##",
					"902#-##-##",
					"903#-##-##",
					"904#-##-##",
					"905#-##-##",
					"906#-##-##",
					"907#-##-##",
					"908#-##-##",
					"909#-##-##"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Pakistan",
				Iso2Code: "PK",
				PhoneNumberCode: "+92",
				FlagImageUrl: "https://flagcdn.com/32x24/pk.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Palau",
				Iso2Code: "PW",
				PhoneNumberCode: "+680",
				FlagImageUrl: "https://flagcdn.com/32x24/pw.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Palestine",
				Iso2Code: "PS",
				PhoneNumberCode: "+970",
				FlagImageUrl: "https://flagcdn.com/32x24/ps.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Panama",
				Iso2Code: "PA",
				PhoneNumberCode: "+507",
				FlagImageUrl: "https://flagcdn.com/32x24/pa.png",
				PhoneNumberMasks: ["###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Papua New Guinea",
				Iso2Code: "PG",
				PhoneNumberCode: "+675",
				FlagImageUrl: "https://flagcdn.com/32x24/pg.png",
				PhoneNumberMasks: ["(###)##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Paraguay",
				Iso2Code: "PY",
				PhoneNumberCode: "+595",
				FlagImageUrl: "https://flagcdn.com/32x24/py.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Peru",
				Iso2Code: "PE",
				PhoneNumberCode: "+51",
				FlagImageUrl: "https://flagcdn.com/32x24/pe.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Philippines",
				Iso2Code: "PH",
				PhoneNumberCode: "+63",
				FlagImageUrl: "https://flagcdn.com/32x24/ph.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Pitcairn",
				Iso2Code: "PN",
				PhoneNumberCode: "+870",
				FlagImageUrl: "https://flagcdn.com/32x24/pn.png",
				PhoneNumberMasks: ["###-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Poland",
				Iso2Code: "PL",
				PhoneNumberCode: "+48",
				FlagImageUrl: "https://flagcdn.com/32x24/pl.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Portugal",
				Iso2Code: "PT",
				PhoneNumberCode: "+351",
				FlagImageUrl: "https://flagcdn.com/32x24/pt.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Puerto Rico",
				Iso2Code: "PR",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/pr.png",
				PhoneNumberMasks: ["(787) ### ####", "(939) ### ####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Qatar",
				Iso2Code: "QA",
				PhoneNumberCode: "+974",
				FlagImageUrl: "https://flagcdn.com/32x24/qa.png",
				PhoneNumberMasks:
				[
					"31-###-###",
					"33-###-###",
					"55-###-###",
					"66-###-###",
					"77-###-###"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Reunion",
				Iso2Code: "RE",
				PhoneNumberCode: "+262",
				FlagImageUrl: "https://flagcdn.com/32x24/re.png",
				PhoneNumberMasks: ["#####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Romania",
				Iso2Code: "RO",
				PhoneNumberCode: "+40",
				FlagImageUrl: "https://flagcdn.com/32x24/ro.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Russia",
				Iso2Code: "RU",
				PhoneNumberCode: "+7",
				FlagImageUrl: "https://flagcdn.com/32x24/ru.png",
				PhoneNumberMasks: ["(###)###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Rwanda",
				Iso2Code: "RW",
				PhoneNumberCode: "+250",
				FlagImageUrl: "https://flagcdn.com/32x24/rw.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Barthelemy",
				Iso2Code: "BL",
				PhoneNumberCode: "+590",
				FlagImageUrl: "https://flagcdn.com/32x24/bl.png",
				PhoneNumberMasks: ["###-##-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Helena, Ascension and Tristan Da Cunha",
				Iso2Code: "SH",
				PhoneNumberCode: "+290",
				FlagImageUrl: "https://flagcdn.com/32x24/sh.png",
				PhoneNumberMasks: ["####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Kitts and Nevis",
				Iso2Code: "KN",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/kn.png",
				PhoneNumberMasks: ["(869)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Lucia",
				Iso2Code: "LC",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/lc.png",
				PhoneNumberMasks: ["(758)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Martin",
				Iso2Code: "MF",
				PhoneNumberCode: "+590",
				FlagImageUrl: "https://flagcdn.com/32x24/mf.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Pierre and Miquelon",
				Iso2Code: "PM",
				PhoneNumberCode: "+508",
				FlagImageUrl: "https://flagcdn.com/32x24/pm.png",
				PhoneNumberMasks: ["##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saint Vincent and the Grenadines",
				Iso2Code: "VC",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/vc.png",
				PhoneNumberMasks: ["(784)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Samoa",
				Iso2Code: "WS",
				PhoneNumberCode: "+685",
				FlagImageUrl: "https://flagcdn.com/32x24/ws.png",
				PhoneNumberMasks: ["##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "San Marino",
				Iso2Code: "SM",
				PhoneNumberCode: "+378",
				FlagImageUrl: "https://flagcdn.com/32x24/sm.png",
				PhoneNumberMasks: ["####-######"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Sao Tome and Principe",
				Iso2Code: "ST",
				PhoneNumberCode: "+239",
				FlagImageUrl: "https://flagcdn.com/32x24/st.png",
				PhoneNumberMasks: ["##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Saudi Arabia",
				Iso2Code: "SA",
				PhoneNumberCode: "+966",
				FlagImageUrl: "https://flagcdn.com/32x24/sa.png",
				PhoneNumberMasks:
				[
					"50-###-####",
					"51-###-####",
					"53-###-####",
					"54-###-####",
					"55-###-####",
					"56-###-####",
					"570-##-####",
					"571-##-####",
					"572-##-####",
					"576-##-####",
					"577-##-####",
					"578-##-####"
				]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Senegal",
				Iso2Code: "SN",
				PhoneNumberCode: "+221",
				FlagImageUrl: "https://flagcdn.com/32x24/sn.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Serbia",
				Iso2Code: "RS",
				PhoneNumberCode: "+381",
				FlagImageUrl: "https://flagcdn.com/32x24/rs.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Seychelles",
				Iso2Code: "SC",
				PhoneNumberCode: "+248",
				FlagImageUrl: "https://flagcdn.com/32x24/sc.png",
				PhoneNumberMasks: ["#-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Sierra Leone",
				Iso2Code: "SL",
				PhoneNumberCode: "+232",
				FlagImageUrl: "https://flagcdn.com/32x24/sl.png",
				PhoneNumberMasks: ["##-######"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Singapore",
				Iso2Code: "SG",
				PhoneNumberCode: "+65",
				FlagImageUrl: "https://flagcdn.com/32x24/sg.png",
				PhoneNumberMasks: ["####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Sint Maarten",
				Iso2Code: "SX",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/sx.png",
				PhoneNumberMasks: ["(721)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Slovakia",
				Iso2Code: "SK",
				PhoneNumberCode: "+421",
				FlagImageUrl: "https://flagcdn.com/32x24/sk.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Slovenia",
				Iso2Code: "SI",
				PhoneNumberCode: "+386",
				FlagImageUrl: "https://flagcdn.com/32x24/si.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Solomon Islands",
				Iso2Code: "SB",
				PhoneNumberCode: "+677",
				FlagImageUrl: "https://flagcdn.com/32x24/sb.png",
				PhoneNumberMasks: ["#####", "###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Somalia",
				Iso2Code: "SO",
				PhoneNumberCode: "+252",
				FlagImageUrl: "https://flagcdn.com/32x24/so.png",
				PhoneNumberMasks: ["#-###-###", "##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "South Africa",
				Iso2Code: "ZA",
				PhoneNumberCode: "+27",
				FlagImageUrl: "https://flagcdn.com/32x24/za.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "South Georgia and the South Sandwich Islands",
				Iso2Code: "GS",
				PhoneNumberCode: "+500",
				FlagImageUrl: "https://flagcdn.com/32x24/gs.png",
				PhoneNumberMasks: ["#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "South Sudan",
				Iso2Code: "SS",
				PhoneNumberCode: "+211",
				FlagImageUrl: "https://flagcdn.com/32x24/ss.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Spain",
				Iso2Code: "ES",
				PhoneNumberCode: "+34",
				FlagImageUrl: "https://flagcdn.com/32x24/es.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Sri Lanka",
				Iso2Code: "LK",
				PhoneNumberCode: "+94",
				FlagImageUrl: "https://flagcdn.com/32x24/lk.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Sudan",
				Iso2Code: "SD",
				PhoneNumberCode: "+249",
				FlagImageUrl: "https://flagcdn.com/32x24/sd.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Suriname",
				Iso2Code: "SR",
				PhoneNumberCode: "+597",
				FlagImageUrl: "https://flagcdn.com/32x24/sr.png",
				PhoneNumberMasks: ["###-###", "###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Svalbard and Jan Mayen",
				Iso2Code: "SJ",
				PhoneNumberCode: "+47",
				FlagImageUrl: "https://flagcdn.com/32x24/sj.png",
				PhoneNumberMasks: ["(###)##-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Sweden",
				Iso2Code: "SE",
				PhoneNumberCode: "+46",
				FlagImageUrl: "https://flagcdn.com/32x24/se.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Switzerland",
				Iso2Code: "CH",
				PhoneNumberCode: "+41",
				FlagImageUrl: "https://flagcdn.com/32x24/ch.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Syrian Arab Republic",
				Iso2Code: "SY",
				PhoneNumberCode: "+963",
				FlagImageUrl: "https://flagcdn.com/32x24/sy.png",
				PhoneNumberMasks: ["##-####-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Taiwan",
				Iso2Code: "TW",
				PhoneNumberCode: "+886",
				FlagImageUrl: "https://flagcdn.com/32x24/tw.png",
				PhoneNumberMasks: ["####-####", "#-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Tajikistan",
				Iso2Code: "TJ",
				PhoneNumberCode: "+992",
				FlagImageUrl: "https://flagcdn.com/32x24/tj.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Tanzania, United Republic of Tanzania",
				Iso2Code: "TZ",
				PhoneNumberCode: "+255",
				FlagImageUrl: "https://flagcdn.com/32x24/tz.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Thailand",
				Iso2Code: "TH",
				PhoneNumberCode: "+66",
				FlagImageUrl: "https://flagcdn.com/32x24/th.png",
				PhoneNumberMasks: ["##-###-###", "##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Timor-Leste",
				Iso2Code: "TL",
				PhoneNumberCode: "+670",
				FlagImageUrl: "https://flagcdn.com/32x24/tl.png",
				PhoneNumberMasks: ["###-####", "77#-#####", "78#-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Togo",
				Iso2Code: "TG",
				PhoneNumberCode: "+228",
				FlagImageUrl: "https://flagcdn.com/32x24/tg.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Tokelau",
				Iso2Code: "TK",
				PhoneNumberCode: "+690",
				FlagImageUrl: "https://flagcdn.com/32x24/tk.png",
				PhoneNumberMasks: ["####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Tonga",
				Iso2Code: "TO",
				PhoneNumberCode: "+676",
				FlagImageUrl: "https://flagcdn.com/32x24/to.png",
				PhoneNumberMasks: ["#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Trinidad and Tobago",
				Iso2Code: "TT",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/tt.png",
				PhoneNumberMasks: ["(868)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Tunisia",
				Iso2Code: "TN",
				PhoneNumberCode: "+216",
				FlagImageUrl: "https://flagcdn.com/32x24/tn.png",
				PhoneNumberMasks: ["##-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Turkey",
				Iso2Code: "TR",
				PhoneNumberCode: "+90",
				FlagImageUrl: "https://flagcdn.com/32x24/tr.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Turkmenistan",
				Iso2Code: "TM",
				PhoneNumberCode: "+993",
				FlagImageUrl: "https://flagcdn.com/32x24/tm.png",
				PhoneNumberMasks: ["#-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Turks and Caicos Islands",
				Iso2Code: "TC",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/tc.png",
				PhoneNumberMasks: ["(249)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Tuvalu",
				Iso2Code: "TV",
				PhoneNumberCode: "+688",
				FlagImageUrl: "https://flagcdn.com/32x24/tv.png",
				PhoneNumberMasks: ["2####", "90####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Uganda",
				Iso2Code: "UG",
				PhoneNumberCode: "+256",
				FlagImageUrl: "https://flagcdn.com/32x24/ug.png",
				PhoneNumberMasks: ["(###)###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Ukraine",
				Iso2Code: "UA",
				PhoneNumberCode: "+380",
				FlagImageUrl: "https://flagcdn.com/32x24/ua.png",
				PhoneNumberMasks: ["(##)###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "United Kingdom",
				Iso2Code: "GB",
				PhoneNumberCode: "+44",
				FlagImageUrl: "https://flagcdn.com/32x24/gb.png",
				PhoneNumberMasks: ["##-####-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "United States",
				Iso2Code: "US",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/us.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Uruguay",
				Iso2Code: "UY",
				PhoneNumberCode: "+598",
				FlagImageUrl: "https://flagcdn.com/32x24/uy.png",
				PhoneNumberMasks: ["#-###-##-##"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Uzbekistan",
				Iso2Code: "UZ",
				PhoneNumberCode: "+998",
				FlagImageUrl: "https://flagcdn.com/32x24/uz.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Vanuatu",
				Iso2Code: "VU",
				PhoneNumberCode: "+678",
				FlagImageUrl: "https://flagcdn.com/32x24/vu.png",
				PhoneNumberMasks: ["#####", "##-#####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Venezuela, Bolivarian Republic of Venezuela",
				Iso2Code: "VE",
				PhoneNumberCode: "+58",
				FlagImageUrl: "https://flagcdn.com/32x24/ve.png",
				PhoneNumberMasks: ["(###)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Vietnam",
				Iso2Code: "VN",
				PhoneNumberCode: "+84",
				FlagImageUrl: "https://flagcdn.com/32x24/vn.png",
				PhoneNumberMasks: ["##-####-###", "(###)####-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Virgin Islands, British",
				Iso2Code: "VG",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/vg.png",
				PhoneNumberMasks: ["(284)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Virgin Islands, U.S.",
				Iso2Code: "VI",
				PhoneNumberCode: "+1",
				FlagImageUrl: "https://flagcdn.com/32x24/vi.png",
				PhoneNumberMasks: ["(340)###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Wallis and Futuna",
				Iso2Code: "WF",
				PhoneNumberCode: "+681",
				FlagImageUrl: "https://flagcdn.com/32x24/wf.png",
				PhoneNumberMasks: ["##-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Yemen",
				Iso2Code: "YE",
				PhoneNumberCode: "+967",
				FlagImageUrl: "https://flagcdn.com/32x24/ye.png",
				PhoneNumberMasks: ["#-###-###", "##-###-###", "###-###-###"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Zambia",
				Iso2Code: "ZM",
				PhoneNumberCode: "+260",
				FlagImageUrl: "https://flagcdn.com/32x24/zm.png",
				PhoneNumberMasks: ["##-###-####"]
			),
			new Country(
				Id: Guid.NewGuid(),
				Name: "Zimbabwe",
				Iso2Code: "ZW",
				PhoneNumberCode: "+263",
				FlagImageUrl: "https://flagcdn.com/32x24/zw.png",
				PhoneNumberMasks: ["#-######"]
			)
		];
	}
}
