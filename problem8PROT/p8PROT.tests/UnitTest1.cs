using NUnit.Framework;
using p8PROT;

namespace p8PROT.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SampleDatasetTest()
        {
            var proteinString = Class1.mapFromRNAToAminoAlphabet("AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA");

            Assert.AreEqual("MAMAPRTEINSTRING", proteinString);
        }

        [Test]
        public void SampleTestFromDisk() 
        {
            string text = System.IO.File.ReadAllText(@"D:\git\biotek-kata\problem8PROT\p8PROT.tests\rosalind_prot.txt");
            var proteinString = Class1.mapFromRNAToAminoAlphabet(text);
            Assert.AreEqual("MAMAPRTEINSTRING", proteinString);
        }

        [Test]
        public void ActualTestFromDisk()
        {
            //Note, manually stripped the CRLF at the end of the string
            string text = System.IO.File.ReadAllText(@"D:\git\biotek-kata\problem8PROT\p8PROT.tests\rosalind_prot.txt");
            var proteinString = Class1.mapFromRNAToAminoAlphabet(text);
            Assert.AreEqual("MPRILRFERLQVKILASYWLLGSPKLPFPRNTPIPFKSIRKDFCGHCSASASVRLALLLVHYTLVLRLVRVDNRDSPSFLSICQHSSGATVIGQNLLLAVGLANWLADLARSVVKDTHLETCHARSCRLFYSINNCLRSRPKSTKINPDLYLFRSVLPFGPPARYEGSAMERQDAHAKKRPVQKESVTVRNLRRSTVLIVVISPLVSSLRFRLNPYLMSQESIPHSGSINGRRKNSVWLDNLLKRACRLGEFSADSEILHSRSYLFLSRSNAIQTHTISLLGEVYWEIPPPAITSNSLPSRLLWNYHTHRPLKKFPVTKRIVVAVFSASFSKLGIVDRGVIPKAFVQGYGGIAISWRRPMTVKKNFGCDYCNNYRRSLDIPQGRKPKVVGAAKAISRAYADYRFSGPKSTATSYAFTIKASSVLLCGHCTHGLLCETSRMCWVYRGWIGERITRPYRDVNVSSLATSLNLSTFVRDLGLKVWLNKFPGVQGAVWNSSKLKPVSTDMSTLCICSKTFAAKRALCLPPGSSANTARARYQKLRTWYARNSIPPPSNIRTNATRAQGDGGVSRKVTSLFIMEFLLSRTQFSLPSLLDGSGVSPRLCRSISSLEPATDQRIAVPWASEEFCQAAQDPYGFCPTAACYELFKTLCPCYALVINYVNHATPALRKLAILTPTKLPEHTPNSKHLCVANHAHTALRSDIRSDTRRQVINKLRAVANGSEHLKEIITTCAYFCAKRMTGGGLPINIRRPRRATSVTSLTSYPSHKNHETFLLTRITEPRSRGAVERSSEKTVLPTPSIPGVLERTSSPCGREGVPAIDSCSRRVGALRTLNCATSAEGAIFSAWGLALLECLAGSPLNHGKTNALALHQNGKSAVTLRYTGPLTAPLHIRQTGISWRACLLRGCRLRDKYHRKLPSLTFKSHWARLFGYMCFDPSTILEYALSPGGVTNALHTCITIRGVAPGKSYSSFQGVCAQGMPAGKRRRRGTWLSPERARATTGELSPTLPGYNPAALARAPIPTLEHCQLHFAPMFRYASSMSTATSDPISRPDDFHAVLRNLRRVHRLGAVLRERWGHARAGFVATIAVMHLVYFARKCIFCQNVRYGNQQPFQPDQRCHNTCCYRSRPRPEKLSGGFGALIVWSHSIGRYPVRARTWPCALSEWLLPASPQVLDNDYAYSTDLRPRAATIRNPLEAKSGTNIALLSREFIRIWDTYKLPPNQRCAVLRLAGEAPNERNPALERGRIPPERLRITPEARINRPLLNVCQERFRDPELFGSMLFPLNAPYQIALTPGMPPISIIDPSPPVCMLADGTPVGSHTVDHHIVVVRMTLKVFNVEEQEQPYVGQLELRSRYTSSLRRTRTHRTIWVAGGSLGAPKVPAIAGAIAYRRWSYLPYRSLAARQLDASELCIMRQACHYGHTLIGCGRGTGVAREFQRLRKELRICNLLLGVSGKRVAPKALDSSAATETEQQTQGHASLTGLSQSGPKGAREDTRMPFVCIHCIPVRQLLCDTHLANSAKAVSTASMQCVSFCSRRETSVIGRLIGERGQFPTENSPSTHRNRTLGPIAPVYKTPRADKQCCASFPIWRTERVYAAVSISQRHSTFTCAALARFLLTLTVSCDASPCLEILPPQGGWMTASLVTYTPPLPIGRAWSALLLLKRYTSTLRVLYMFAYYTSGVTMHFRLPDLLSPEYSLSRPVTISEDCGLGRARRVNPNARVCPQSFICSKCSVNHLEDIESTTQIHRVCRNGPSFPIWYKIKRGYRGGWYIKKRVFSLEGWRTFILLGVLHTTLYMLASATNEYSESLKSSVYRVYNKRPAVRLEMNREPHLTRKLPGTCTGREGSHILVEARSGSTFKTEEARQSYKVDSEHPMIAWSRIWSNFGGVHALTDRVQFKVRIYPRIFHLRPHAIQAGLPTFVSQRPSPSPKLANNESLCPKTPVLMTPLFGPAPGAPKTGLTVDGCLRKIAGFFNPWQCIPITPSRPIKTNVYSKLQHLPEYAHALIEARTIRVQVLSRYPISKDGLKATGIPAGTRYGRLRQDDAEDSAARDPQLVLQPGQKRRLGCSHLNRLRRIDSAGGNVSVLPRIAHVSRWDILQSLPAFTSYGVMRLDVVMREILSSGGLQRPALPSIFFITRIPKNLRIQEHVRVVKQLETYRFLQRACRQLTFFSTRWKPAEHGPEHFLVHSTSSVVQCSSGHLDAVENDQKGRKMLIKGESPLTTMRNRYRFVSPEIRWRTTLPYGEHPDFILRIQSGLPGQLMVSLGPRFPPYRGGERCSFEALSLPITGALRMSGMCMPVRRTKTLGLEHALLEVPSNKLQYLGLSRLAAEHTGTVNFTKHTTYGIASRHGQYCILTPLRRLEREGWVPHIPIGGHKVACRDNTLFSRYRESMPRSVIVMLANDQGTISHRMIRVSVIGLWGDLRTFIELGCVQVATGQRTLFYSTRAPVGSRKVSARSTAPLEFIPVLGCLDAGLRQTRLHSFPLFDGLLRLGRGEGLVWEFQCSGPQGNDLSIVSSRFILPGPISRSCPACIQIRKDDMVILPTKSHWGANNQISSRSHKVLYRPPPVMVTDTNLKYIKGFPIAIARDYYARVFTDFETSGVSFPRALLFLARQTTDRLLIDAYLLRQIVHYMLPDRVGEVSELLLHENRSMISPDIPRRSDAVPGYCQLVSITDPTFFAGIIKFRTQSVHLDSKSKSFKNAAPKRLSVMTISICVHKHTLFLSVTTTHECVRIETRGRRCCPKPGYASDPSLSSFQESKSLSAPYEAKCNGMMISQEAMCSTLLRSEPCSRRSSCSQHSGHGDSLMTVLKCKRQESAPRDSILLQTRGNEISGSRFGDRRLAASPASGQLIETHRLALDIWVDTYEEEPVHGRSFSSPAFILCRFIFPQPTLELPTPGSSSSHCPRLVALSLCQPSYKSLERAPADRHTSCNEASVSAEFKLQCGRPWIFTPILSKSCWARSFRDLGRENMRLIVWAGGNSLFVDSNYTGLGSTPTLIKPGEVARLIDYLIGDENVKATRNGFAWVRFRTSETTYETSGWPGANFMDGLGIFGLAARLVFYGLAIKHCIPAYSGTKMDDFTPVGNDRLPCATRRTDTPASTALVDQLWGARFCIILQISDPYIGVLLPANGISCLLVVRSRYSFLARKSYSRCSILPVTNVTPRQGGLFPMRCHPQSCNYASGKPQCLTIFEPLTQGIGPIQVGAETDRI", proteinString);
        }

    }
}