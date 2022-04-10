using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Önce gelip objemizi gameobject olarak tanıtıyoruz.bir sürü olacağı için serialized şeklinde tanıtıyoruz.
    //Serialized demek inspector panelinde gözüksün ona obje atayabilelim fakat diğer scriptlerden erişilemesin diye yapılıyor.
    //yani ne public ne private ikisi arasında.
    [SerializeField]
    GameObject karePrefabcd;

    //başına transform yazarak yine aynı şekilde karelerin yerleşeceği paneli tanımlıyoruz.
    // bir değer atayacağımız her şeyi tanımlıyoruz kısacası aq
    [SerializeField]
    Transform karelerPanelicd;

    //Burda da kareleri bir dizinin içinde saklamak için dizi tanımlıyoruz.
    private GameObject[] karelerDizisicd = new GameObject[25];



    void Start()
    {
        //fonksiyonu aşağıda tanımlıyoruz burda sadece adını yazıyoruz ve fonksiyonu yazdığımız yerden çağırmış oluyoruz.
        kareleriOlustur();
    }


    //fonksiyonumuza burda bir isim veriyoruz.İsmi kendi istediğimiz bir şey verebildiğimizi göstermek için hepsinin sonuna cd ekliyorum.
    public void kareleriOlustur()
    {
        //bak şimdi burda diyoruz ki sıfırdan başlayarak 25 kadar belirtmiş olduğum dizideki objelerin hepsi bir gameobject ve
        //hepsinin ismine kare de 
        for (int i = 0; i < 25; i++)
        {
            GameObject kare = Instantiate(karePrefabcd, karelerPanelicd);
            karelerDizisicd[i] = kare;
            //instantiate fonksiyonu prefab çoğaltmak için kullanılıyor.
            //parantezin içindeki ilk kelime çoğaltılacak prefabın ismi
            //ikinci kelime ise nerede üretileceği. Bu ikinci kelimede panelin yerine vector3 fonksiyonununda geldiği durumlar mevcut
            //başka oyunlarda görürsün büyük ihtimal şimdi kurcalama
            //instantiate yazınca zaten sırasıyla hangi değerleri alabileceği yanında çıkıyor instantiate yaz görürsün
            //karelerin panelin içerisinde sıralı bi şekilde oluşması panele atadığımız layout componenti ile ilgili ona unity içerisinden
            //git bak

        }
        degerleriKarelereYazdir();

        StartCoroutine(DOFadeRoutine());
    }
    
    //IEnumeratorden sonra fonksiyona istediğimiz mantıklı bir isim veriyoruz burda fade yaratması için yaptığımızdan
    //DOFadeRoutine ismi verdik ama ahmet mehmette diyebilirdik
    //Farkettiysen fonksiyonu aşağıda tanımladık ama kareleriOlustur fonksiyonunun içinde çalıştırdık böyle yapabiliriz.
    //coroutine fonksiyonunda yield return satırının mutlaka olması gerekiyor.
    IEnumerator DOFadeRoutine()
    {
        foreach (var kare in karelerDizisicd)
        {
            kare.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
            //burdaki olayda diyoruz ki ben canvasGroup özelliğindeki alpha kanalını 0 dan 1 çekmek istiyorum yani
            //transparandan normal image görüntüsüne gelmek istiyorum bunu da 0.2 saniyede yap 
            //aşağıdaki yield ile bunu karıştırma orda karelerin arasındaki süreyi tanımlıyorsun burda karenin ekrana geleceği süreyi

            yield return new WaitForSeconds(0.06f);
            //IE numarator kullanmamızın sebebi kareleri oluşturduğu aralara 0.06 saniye eklemek istememiz
            //yield return satırı diyor ki bu satırı okuduktan sonra 0.06 saniye bekle 
        }
    }

    void degerleriKarelereYazdir()
    {
        foreach (var kare in karelerDizisicd)
        {
            int rastgeleDeger = Random.Range(1,13);

            kare.transform.GetChild(0).GetComponent<Text>().text = rastgeleDeger.ToString();
            //yukarıdaki ifadeyi okuyalım
            //karenin transform içerisindeki 0 ıncı childını get yap (prefabda altına atılmış ilk nesneyi bul yani)
            //bu bir <Text> olacak sonra buraya ().text kullanarak bir text yazdır bu da eşit olsun = bir üst satırda tanımladığın
            //rastgeleDeger değişkenine sonra bunu stringe çevirmeyi unutma To.String()

            // degerleriKarelereYazdir fonksiyonunu kareler sahneye gelmeden yazdırman lazım o yüzden yukarı çıkıp kareleriOlustur
            // fonksiyonunun içine yazdık
        }
    }

}
