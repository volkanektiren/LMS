# LMS (Library Management System)

### Projenin local ortamda ayağa kaldırılması
- compose.yaml dosyanı dockerda yürütüp, minio ve mssql ayağa kaldırılabilir
- minio nun UI client ı üzerinden 'files' adında bir bucket oluşturulup, bucket a erişimi sağlayan access ayarının public e çekilmesi gerekir
- minio bucket ını oluşturulduktan sonra ekrana gelen access ve secret keylerinin projenin appsettingsinde ki minio a kısmına eklenmelidir
- minio ve mssql port bilgilerinin docker ve proje appsettingsde aynı olması gerekir
- mssql den LMS isimli bir db oluşturulur
- nuget package manager console dan default project Core ve startup project i LMS seçerek Update-Database yapılarak migration çekilmelidir

### Proje Tanıtımı
- Proje ayağa kaldırıldığında aşağıda ki ekran açılacaktır. Ekranda ki tabloda sistemde bulunan kitap bilgileri alfabetik bir şekilde yer alır. Kitap resmi minio object storage ında tutulur ve path bilgisi veritabanına kaydedilir. <img width="1274" alt="image" src="https://github.com/volkanektiren/LMS/assets/44165996/30cb95c1-9ee8-4513-b03e-d5aac9771e19">
<br /><br />
- Add a New Book düğmesiyle aşağıda ki ekran gelir. Açılan forma kitap bilgileri girildikten sonra create düğmesine tıklayarak kaydedilir ve yeni eklenen kitap tabloda listelenir. <img width="1268" alt="image" src="https://github.com/volkanektiren/LMS/assets/44165996/d3106f60-c869-4c1b-bc22-fde5d545a4f5">
<br /><br />
- Visitors düğmesiyle aşağıda ki gibi ziyaretçilerin bilgilerinin yer aldığı bir tablo açılır. Açılan ekrandan Add düğmesine tıklanarak yeni ziyaretçi eklenebilir. <img width="1273" alt="image" src="https://github.com/volkanektiren/LMS/assets/44165996/9c2b67a3-f9f3-4298-adb7-35a5b54f5b2f">
<br /><br />
- Kitap tablosunda ki status kolonunda kitabın kütüphane içinde mi yoksa dışında mı bilgisi tutulur ve Lend It düğmesine tıklayarak kitap ödünç verilebilir. Açılan formda ki choose a visitor select dropdownında listelenen ziyaretçilerden biri seçilir. Lend düğmesine tıklarak ödünç verme işlemi tamamlanır ve kitap tablosu güncellenir. <img width="1271" alt="image" src="https://github.com/volkanektiren/LMS/assets/44165996/4da90181-7e4a-4b49-8d9c-775a30fa5c15">
<br /><br />
- Kütüphane dışına çıkan kitap bilgisinin status kısmında, Lend It düğmesi yerine Lending Details düğmesi yer alır. Bu düğmeye tıklayarak açılan ekranda ödünç verme detayları gösterilir ve Refund düğmesine tıklanarak ziyaretçiden kitap geri iade alınır. <img width="1261" alt="image" src="https://github.com/volkanektiren/LMS/assets/44165996/8abfd994-215e-4989-80c5-f78cf12497b6"> <img width="1270" alt="image" src="https://github.com/volkanektiren/LMS/assets/44165996/3da0a1a7-0e5e-476c-9180-dcc043046ba3">



