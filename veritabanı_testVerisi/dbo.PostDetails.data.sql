INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (1, N'<p><strong>0.1 Soyutlaştırma</strong></p>

<p><strong>0.2 Nedir?</strong></p>

<p>&bull; Buzdağı: Detaylar altta, kullanılabilir kısım &uuml;stte. &Uuml;st&uuml;nde yaşayan hayvanlar detayla ilgilenmiyor.<br />
&bull; Kullanıcı: &ldquo;nasıl kullanırım &rdquo;, Geliştirici: &ldquo;nasıl &ccedil;alışır?&rdquo;<br />
&bull; Kullanıcı: &ldquo;ne yapar?&rdquo;, Geliştirici: &ldquo;nasıl yapar?&rdquo;<br />
&bull; Soyutlaştırma: Geliştirilen programın/tasarımın detaylarını saklayarak bir mekanizma ile kolay kullanılır<br />
ve tekrar tekrar kullanılır hale getirmek.<br />
&bull; Program par&ccedil;alarının kullanımı ve uygulanmasının ayırılması.<br />
&bull; B&uuml;y&uuml;k &ouml;l&ccedil;ekli programlamanın vazge&ccedil;ilmez gereksinimi.<br />
&bull; Genel olarak tasarımın s&ouml;z konusu olduğu bir&ccedil;ok branşta ge&ccedil;erli.<br />
&bull; &Ouml;rnek: radyolarda sadece belirlenen frekanstaki dalgaların ge&ccedil;işini sağlayan bir devre elemanı vardır<br />
(tuner). Bu elemanın ayarını sağlayan potansiyometre radyonun dışında bir d&uuml;ğme olarak kontrol<br />
edilir. Radyonun ayar d&uuml;ğmesi &ldquo;tuner&rdquo; ayarı &uuml;zerine bir soyutlaştırmadır.<br />
&bull; Programlama dilleri makina dili &uuml;zerine bir soyutlaştırmadır.<br />
&bull; Grafik aray&uuml;zl&uuml; programlar karmaşık program mantığının &uuml;zerine bir soyutlaştırmadır.<br />
<br />
<br />
<strong>0.3 Ama&ccedil;:</strong><br />
&bull; Detaylar kafa karıştırıcı<br />
&bull; Detaylarda Hata yapması kolay<br />
&bull; Detayların tekrarlanması zor ve hata arttırıcı etmen<br />
&bull; Soyutlaştırma ile Bir kere tanımla, istediğin kadar kullan!<br />
&bull; Programın tekrar kullanılırlığı en &ouml;nemli ama&ccedil;<br />
&bull; Soyutlaştırmada parametre kullanarak etkinliği arttırmak m&uuml;mk&uuml;n<br />
<br />
<br />
<br />
<strong>0.4 Fonksiyon ve altyordam soyutlaştırmaları</strong><br />
<br />
Fonksiyon ve altyordam soyutlaştırmaları<br />
<br />
&bull; Bir ifadenin hesaplanması detay (algoritma, değişken alanı kullanımı vs.)<br />
&bull; Fonksiyon &ccedil;ağrısı o detayı kullanma şekli.<br />
&bull; Fonksiyonlar ifadeler &uuml;zerinde bir soyutlaştırma<br />
&bull; void d&ouml;nen fonksiyonlar ya da bazı dillerde procedure tanımları.<br />
&bull; Değerleri yok fakat bir grup komut detayından oluşur.<br />
&bull; Altyordamlar komutlar &uuml;zerinde bir soyutlaştırma&nbsp;<br />
<br />
<br />
<strong>0.5 Se&ccedil;ici soyutlaştırması&nbsp;</strong><br />
<br />
&bull; Başka soyutlaştırmalar m&uuml;mk&uuml;n m&uuml;?&nbsp;<br />
&bull; Dizilerde: int a[10][20]; a[i]=a[i]+1;<br />
&bull; [..]operat&ouml;r&uuml; bir se&ccedil;ici. Dizinin elemanlarını se&ccedil;iyor.&nbsp;<br />
&bull; Kullanıcı kendi veri yapısı &uuml;zerine se&ccedil;ici tanımlayabilir mi?&nbsp;<br />
&bull; Bağlı listelerde bir se&ccedil;ici (C++)&nbsp;<br />
<br />
&nbsp;</p>

<hr />
<p>&nbsp;</p>
')
INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (2, N'<p>Bu yazımızda, &rsquo;Button ismiyle bilinen d&uuml;ğme standart kontrol&uuml;n&uuml;, bu kontrol&uuml;n API fonksiyonları ile oluşturulmasını, kontrole g&ouml;nderilen ve kontrolden gelen mesajların işlenmesini inceleyeceğiz. Windows sistemlerinin, kullanıcı ile uygulama programlarının haberleşmesini sağlayabilmek i&ccedil;in sunduğu kontrollerden birisi de d&uuml;ğme kontrol&uuml;d&uuml;r. Kullanıcı d&uuml;ğme kontrol&uuml;n&uuml; kullanarak, uygulama i&ccedil;erisinde belli bir işlemi başlatabilir, bir işleme onay verebilir, bir işlemden vazge&ccedil;ebilir. D&uuml;ğme kontrol&uuml; &uuml;zerine fare ile bir kez basıldığında, kontrol basılı hale ge&ccedil;er. Farenin tuşunu serbest bıraktığımızda ise kontrol normal konumuna geri d&ouml;ner.<br />
<br />
<br />
Windows sistemleri beş &ccedil;eşit d&uuml;ğme kontrol&uuml; sunarlar. Bu kontrollerin hepsi aynı pencere sınıf ismi (button) kullanılarak oluşturulur. Bu d&uuml;ğme kontrollerinin birbirinden ayırt edilmesi i&ccedil;in birka&ccedil; pencere bi&ccedil;imi sembolik sabiti tanımlanmıştır. Ayrıca her d&uuml;ğme kontrol&uuml; t&uuml;r&uuml; de, kendisine ilişkin bazı pencere bi&ccedil;imlerine sahip olabilir. Kullanıcı fare ya da klavye yoluyla d&uuml;ğme kontrol&uuml;n&uuml; se&ccedil;ili / se&ccedil;ilmemiş duruma getirebilir. D&uuml;ğmenin g&ouml;r&uuml;n&uuml;m&uuml; ve durumu, d&uuml;ğmenin kendisi, uygulama ve Windows tarafından belirlenir. D&uuml;ğme kontrolleri &uuml;st pencerelerine mesaj g&ouml;nderebilir ve &uuml;st pencereden gelen mesajları alabilirler. D&uuml;ğme kontrolleri şunlardır :<br />
<br />
Şimdi d&uuml;ğme kontrol&uuml; t&uuml;rlerini sırayla inceleyelim :<br />
&nbsp;</p>

<blockquote><strong>1. Basma D&uuml;ğmeleri (Push Buttons)</strong><br />
&nbsp;</blockquote>

<p>Basma d&uuml;ğmesi, uygulama tanımlı bir başlık yazısı, bir ikon, bir bitmap i&ccedil;eren bir dikd&ouml;rtgendir. Basma d&uuml;ğmesi iki bi&ccedil;imde olabilir; standart (standard) veya varsayılan (default) bi&ccedil;imler. Bu bi&ccedil;imler, BS_PUSHBUTTON ve BS_DEFPUSHBUTTON sabitleri ile belirlenir. Standart basma d&uuml;ğmesi genellikle bir işlemi başlatmak amacıyla kullanılır. Kullanıcı kontrol&uuml; se&ccedil;tiği zaman, klavye kontrole odaklanır. Varsayılan basma d&uuml;ğmesi genellikle sık&ccedil;a kullanılan veya varsayılan halde kullanılan se&ccedil;enekler belirtmek i&ccedil;in kullanılır. Kullanıcı ENTER tuşuna bastığı zaman kontrol se&ccedil;ilir. Kullanıcı d&uuml;ğme kontrol&uuml;n&uuml; se&ccedil;tiği zaman, kontrol Windows&rsquo;tan klavye odağını alır, kontrol&uuml;n ana penceresine BN_CLICKED bilgi mesajını i&ccedil;eren WM_COMMAND mesajı iletilir.<br />
&nbsp;</p>

<blockquote><strong>2.Se&ccedil;enek Kutusu D&uuml;ğmeleri (Check Boxes</strong><br />
&nbsp;</blockquote>

<p>Se&ccedil;enek kutusu, uygulama tanımlı bir başlık yazısı, bir ikon, bir bitmap ile birlikte kare şeklinde bir kutudan oluşur. Se&ccedil;enek kutuları, kullanıcının birbiri ile ilişkili ancak birbirinden bağımsız olan se&ccedil;enekleri se&ccedil;mesi i&ccedil;in kullanılır. Aralarında mantıksal ilişki olan se&ccedil;enek kutuları, genellikle bir grup kutusu i&ccedil;erisinde toplanır. Se&ccedil;enek kutusu, d&ouml;rt bi&ccedil;imde olabilir; standart (standard), otomatik (automatic), 3-durumlu (three-state) ve otomatik 3-durumlu (automatic three-state) bi&ccedil;imler. Bu bi&ccedil;imler sırayla, BS_CHECKBOX, BS_AUTOCHECKBOX, BS_3STATE ve BS_AUTO3STATE sabitleri ile belirlenir. Bu bi&ccedil;imlerin her birisi iki işaret durumuna sahiptir : se&ccedil;ili olma durumu, se&ccedil;ilmemiş olma durumu. &Uuml;&ccedil; durumlu se&ccedil;enek kutusu, bu durumlara ilave olarak, belirsiz bir duruma sahiptir. Bu durumda iken kontrol gri renkte g&ouml;r&uuml;nt&uuml;lenir. Standart ve otomatik se&ccedil;enek kutularının se&ccedil;ilmesi ile kontroller işaretli duruma, tekrar se&ccedil;ildiklerinde işaretlenmemiş duruma getirilir. &Uuml;&ccedil; durumlu se&ccedil;enek kutularının se&ccedil;ilmesi ile kontrol işaretli duruma, tekrar se&ccedil;ildiklerinde işaretlenmemiş duruma, tekrar se&ccedil;ildiklerinde ise belirsiz duruma getirilir. Kullanıcı herhangi t&uuml;rden bir se&ccedil;enek kutusunu se&ccedil;tiği zaman, kontrol Windows&rsquo;tan klavye odağını alır ve kontrol&uuml;n ana penceresine BN_CLICKED bilgi mesajını i&ccedil;eren WM_COMMAND mesajı iletilir. Ana pencere kontrol&uuml;n otomatik bir se&ccedil;enek kutusu mu, yoksa otomatik 3-durumlu bir se&ccedil;enek kutusu mu olduğunu bilmez. &Ccedil;&uuml;nk&uuml; bu t&uuml;rdeki se&ccedil;enek kutularının işaret durumları Windows tarafından otomatik bir şekilde ayarlanır. Ancak ana pencere, mesajın bir se&ccedil;enek kutusundan mı, yoksa 3-durumlu bir se&ccedil;enek kutusundan mı geldiğini bilmelidir; &ccedil;&uuml;nk&uuml; bu t&uuml;rdeki se&ccedil;enek kutularının işaret durumlarını Windows otomatik olarak ayarlamaz. Se&ccedil;enek kutusu hangi t&uuml;rde olursa olsun, işaret durumu değiştiği zaman, Windows tarafından otomatik olarak yeniden &ccedil;izilir.&nbsp;<br />
<br />
&nbsp;</p>

<blockquote><strong>3. Se&ccedil;enek D&uuml;ğmeleri (Radio Buttons)</strong><br />
&nbsp;</blockquote>

<p>Se&ccedil;enek d&uuml;ğmesi, uygulama tanımlı bir başlık yazısı, bir ikon, bir bitmap ile &ccedil;ember seklinde bir d&uuml;ğmeden oluşur. Se&ccedil;enek d&uuml;ğmeleri, kullanıcının birbirleri ile ilişkili ve buna ek olarak birbirlerine bağımlı birka&ccedil; se&ccedil;enekten birisini se&ccedil;mesi i&ccedil;in kullanılır. Kullanıcı se&ccedil;eneklerden birisini se&ccedil;tiğinde, diğer se&ccedil;eneklerin se&ccedil;ilememesi gereklidir. Se&ccedil;enek d&uuml;ğmesi iki bi&ccedil;imde olabilir; standart (standard) veya otomatik (automatic). Bu bi&ccedil;imler sırayla, BS_RADIOBUTTON ve BS_AUTORADIOBUTTON sabitleriyle belirlenir. Her iki t&uuml;rdeki kontrol i&ccedil;in de, iki işaret durumu vardır : işaretli (d&uuml;ğme i&ccedil;erisine bir nokta &ccedil;izilir) veya işaretlenmemiş (d&uuml;ğme i&ccedil;erisi boş bırakılır). Kullanıcı se&ccedil;enek d&uuml;ğmesini se&ccedil;tiği zaman, kontrol Windows&rsquo;tan klavye odağını alır ve kontrol&uuml;n ana penceresine BN_CLICKED bilgi mesajını i&ccedil;eren WM_COMMAND mesajı g&ouml;nderilir. Ana pencere mesajın otomatik se&ccedil;enek d&uuml;ğmesinden mi geldiğini bilmez; &ccedil;&uuml;nk&uuml; otomatik se&ccedil;enek d&uuml;ğmesinin işaret durumu Windows tarafından ayarlanır. Ancak eğer mesaj normal bir se&ccedil;enek d&uuml;ğmesinden geliyorsa, Windows bunu bilmek zorundadır; &ccedil;&uuml;nk&uuml; bu t&uuml;r i&ccedil;in işaret durumu Windows tarafından ayarlanmaz. Se&ccedil;enek d&uuml;ğmesi hangi t&uuml;rde olursa olsun, işaret durumu değiştiği zaman, Windows tarafından otomatik olarak yeniden &ccedil;izilir.&nbsp;<br />
<br />
&nbsp;</p>

<blockquote><strong>4.Kullanıcı-Tanımlı D&uuml;ğmeler (Owner-Drawn Buttons)</strong>&nbsp;<br />
&nbsp;</blockquote>

<p>Kullanıcı-tanımlı d&uuml;ğmeler, Windows tarafından değil, uygulama tarafından &ccedil;izilir. Bu kontroller i&ccedil;in &ouml;nceden tanımlanmış g&ouml;r&uuml;n&uuml;mler mevcut değildir, g&ouml;r&uuml;n&uuml;mleri ve davranışları tamamen uygulamaya bağlıdır. Bu kontrol i&ccedil;in tek bir bi&ccedil;im tanımlanmıştır, o da BS_OWNERDRAW sabiti kullanılarak oluşturulur. Kontrol se&ccedil;ildiğinde, ana pencereye Windows tarafından BN_CLICKED bilgi mesajını i&ccedil;eren WM_COMMAND mesajı g&ouml;nderilir.&nbsp;<br />
<br />
&nbsp;</p>

<blockquote><strong>5.Grup Kutuları (Group Boxes)</strong>&nbsp;<br />
&nbsp;</blockquote>

<p>Grup kutusu, sol &uuml;st k&ouml;şesinde başlık yazısı bulunan, bir veya birka&ccedil; tane kontrol&uuml; i&ccedil;inde bir arada bulunduran dikd&ouml;rtgen şeklinde bir kontrold&uuml;r. Grup kutuları, aralarında mantıksal ilişki bulunan birka&ccedil; kontrol&uuml; bir arada g&ouml;stermek amacıyla kullanılır. Bu kontrol i&ccedil;in de tek bir bi&ccedil;im tanımlanmıştır, o da BS_GROUPBOX sabiti kullanılarak oluşturulur. Bu kontrole mesaj g&ouml;nderilemez, kontrol&uuml;n işaretli olma/işaretsiz olma gibi durumları da mevcut değildir.&nbsp;<br />
<br />
<br />
D&uuml;ğme kontrolleri yaratılırken CreateWindow ya da CreateWindowEx fonksiyonuna pencere bi&ccedil;imi parametresi olarak ge&ccedil;ilen pencere sınıf ismi &rsquo;button&rsquo;dur. Pencere başlığı parametresi olarak ge&ccedil;tiğimiz karakter katarı ise, d&uuml;ğme kontrol&uuml; &uuml;zerinde g&ouml;r&uuml;nt&uuml;lenecek yazıyı belirtir. &Uuml;&ccedil;&uuml;nc&uuml; parametre yerine ge&ccedil;eceğimiz pencere bi&ccedil;imi ise, yaratmak istediğimiz d&uuml;ğme kontrol&uuml;n&uuml; belirten bir pencere bi&ccedil;imi sabiti olmalıdır. Windows sistemlerinde, d&uuml;ğme kontrolleri i&ccedil;in tanımlanmış pencere bi&ccedil;imi sembolik sabitleri BS_ &ouml;neki ile başlatılmışlardır. Bu pencere bi&ccedil;imi sembolik sabitlerini inceleyelim :</p>
')
INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (3, N'<p><strong>C&rsquo;de makrolar</strong></p>

<p>Makro direktifleri derleme-&ouml;ncesi komutlarıdır. Bunlar tipik olarak kaynak kodları değiştirmek, programı farklı donanımlarda kolaylıkla &ccedil;alıştırabilmek, programın par&ccedil;alarını kaynak programda birleştirmek ve derleme sırasındaki bazı uyarı mesajlarını aktif veya pasif hale getirmek i&ccedil;in kullanılırlar.<br />
C&rsquo;de kullanılar direktifler ş&ouml;yledir:<br />
#Include&nbsp;<br />
#Define<br />
#Pragma<br />
#Line<br />
#Error<br />
#Undef<br />
#Ifdef<br />
#Ifndef<br />
#If<br />
#Else<br />
#Elif<br />
#Endif</p>

<p><strong>1. #Include Direktifi</strong><br />
Bu direktif, verilen dosyanın i&ccedil;eriğini, kullanıldığı yerde kaynak dosyanın i&ccedil;ine ekler. &Ccedil;oğunlukla derleyiciye ait komut k&uuml;t&uuml;phanelerinde bulunan fonksiyonların prototiplerinin (fonksiyon başlık kısımlarının) ve diğer &ccedil;eşit tanımlamalarının bulunduğu (H uzantılı) BAŞLIK dosyalarının programa dahil edilmesinde kullanılır. Direktif iki şekilde kullanılabilir:</p>

<table border="0" cellpadding="1" cellspacing="0" style="width:50%">
	<tbody>
		<tr>
			<td>#Include&lt;DosyaIsmi.H&gt;&nbsp;<br />
			<br />
			#Include &ldquo;DosyaIsmi.H&rdquo;</td>
		</tr>
	</tbody>
</table>

<p><br />
Birinci kullanımda dosyanın nerede bulunduğu derleyici i&ccedil;in verilen ulaşım yolu (path) ile belirlenir. Bu ulaşım yolu genellikle&nbsp;<br />
<br />
INCLUDE dizini ile son bulur. İkinci kullanımda ise dosyanın bulunduğu yer aktif dizin olarak kabul edilir.</p>

<p><strong>2. #Define Direktifi</strong><br />
Kaynak dosyada bir isim yerine başka bir ismin yer değiştirilmesini sağlar.<br />
&nbsp;</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>#Define BEGIN {<br />
			#Define END }<br />
			#Define YAZ printf<br />
			#Define MESAJ &ldquo;Hello Earth.&rdquo;<br />
			#Define PROGRAM main( )&nbsp;
			<p>&nbsp;</p>

			<p>PROGRAM<br />
			BEGIN<br />
			YAZ(MESAJ) ;<br />
			<br />
			&nbsp;</p>
			</td>
		</tr>
	</tbody>
</table>

<p>Yukarıdaki program derleme işleminden evvel define ile verilen isimler yerine ikinci isimler yerleştirildikten sonra program aşağıdaki duruma gelir.<br />
&nbsp;</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>Main( )<br />
			{<br />
			Intf(&ldquo;Hello Earth.&rdquo;) ;<br />
			&nbsp;</td>
		</tr>
	</tbody>
</table>

<p><br />
Bu direktifi kullanarak sembolik program sabitlerini tanımlamakta m&uuml;mk&uuml;nd&uuml;r. &Ouml;rneğin;<br />
&nbsp;</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td><br />
			#Define PI 3.1415
			<p>&nbsp;</p>

			<p>#Define A 0.15454</p>

			<p>#Define C A*P I</p>

			<p>Main( )</p>

			<p>{</p>

			<p>Float x,y ;</p>

			<p>x = 2 * P I</p>

			<p>y = C / 2 . 0 ;</p>

			<p>}</p>
			</td>
		</tr>
	</tbody>
</table>

<p>Bu programda P I g&ouml;r&uuml;ld&uuml;ğ&uuml; yere 3.1415, A yerine 0.15454 ve C yerine A* P I konur, ve program aşağıdaki gibi derlenir:</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td><br />
			Main ( )<br />
			{<br />
			Float x,y ;
			<p>&nbsp;</p>

			<p>x = 2*3.1415<br />
			y = 0.15454*3.1415 / 2 . 0 ;</p>

			<p>}<br />
			&nbsp;</p>
			</td>
		</tr>
	</tbody>
</table>

<p>Burada dikkat edilmesi gereken bir husus vardır, bunu aşağıdaki &ouml;rnekte g&ouml;rebiliriz :</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td><br />
			#Define A 2&nbsp;<br />
			#Define B 7<br />
			#Define C A+B
			<p>&nbsp;</p>

			<p>Main ( )</p>

			<p>{</p>

			<p>Int x ;</p>

			<p>x = 2 * C ;</p>

			<p>Printf ( &ldquo; % d \ n &rdquo; , x ) ;</p>

			<p>}<br />
			&nbsp;</p>
			</td>
		</tr>
	</tbody>
</table>

<p>Burada x&rsquo;in değerinin ne olacağını d&uuml;ş&uuml;nelim. G&ouml;r&uuml;n&uuml;ş olarak x,18 değerine sahip oluyor gibi g&ouml;z&uuml;kmektedir. Şimdi tanımlanan makro sabitlerinin programda nasıl yerleştirildiğini inceleyelim.&Ouml;nce tanımlanan C Makrosunda A ve B yerine 2 ve 7 sayıları konur ve C aşağıdaki duruma gelir.</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>#Define C 2 + 7&nbsp;<br />
			&nbsp;</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<p>Dikkat edilecek olursa makronun g&ouml;revi sadece bir isim yerine başka bir isim koymaktır, bu esnada hesaplama yapılmaz . Yani C makrosu, 9 olarak ele alınmaz. Şimdi C&rsquo;yi programda yerine koyarsak;</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>
			<p>x = 2 * 2 + 7</p>
			</td>
		</tr>
	</tbody>
</table>

<p>durumuna gelir ve sonu&ccedil; 11 olur. Eğer 2 + 7 &lsquo;nin iki katı alınması d&uuml;ş&uuml;n&uuml;ld&uuml; ise bu durumda C makrosu</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>
			<p>#Define C ( A + B )</p>
			</td>
		</tr>
	</tbody>
</table>

<p>Şeklinde tanımlamak gereklidir. Define makrosuna g&uuml;zel bir &ouml;rnek aşağıda verilmiştir. Aşağıdaki programda sonucun M / SN cinsinden &ccedil;ıkması isteniyor, fakat kullanılan veriler Km ve Saat&rsquo;tir.</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>#Define km * 1000.0<br />
			#Define Saat * 3600.0
			<p>&nbsp;</p>

			<p>Main ( )<br />
			{</p>

			<p>Float yol, zaman , hiz ;</p>

			<p>yol = 2 . 5 km ;<br />
			zaman = 3.2 saat ;</p>

			<p>hiz = yol \ zaman ;</p>

			<p>printf ( &ldquo; Hiz = %f m / sn&rdquo; , hiz ) ;</p>

			<p>}<br />
			&nbsp;</p>
			</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<p>Yukarıdaki &ouml;rnekte yol = 2.5 km ; ifadesindeki km makrosu yerine konduktan sonra durum yol= 2.5 * 1000 . 0 olacaktır. Yani km olarak verilen değer metreye &ccedil;evrilmiş olacaktır. Benzer durum zaman i&ccedil;in de ge&ccedil;erlidir. Sonu&ccedil;ta elde edilen hız değeri m / sn biriminde olacaktır. Define makrosu ile parametrik tanımlamalar da yapmak m&uuml;mk&uuml;nd&uuml;r.</p>

<p>&Ouml;rneğin;</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>#Define kare(x) ( (x) * (x) )&nbsp;<br />
			#Define carp (x . y) (x * y)<br />
			#Define yaz( mesaj ) printf ( mesaj ) ;
			<p>&nbsp;</p>

			<p>Main ( )</p>

			<p>{</p>

			<p>Float t, a , b;<br />
			T = 3 . 6 ;<br />
			b = 4 ;&nbsp;<br />
			a = kare ( 3 ) + carp ( t , b ) ;<br />
			printf ( &ldquo;Sonuc =%f&rdquo; a ) ;<br />
			yaz ( &ldquo; islem tamam&rdquo;) ;</p>

			<p>Burada a = kare (3) + carp ( t , b ) ; ifadesi makroların işlenmesinden sonra</p>

			<p>a = ( ( 3 ) * ( 3) ) + (3.6 * 4 ) ; Haline gelir.</p>
			</td>
		</tr>
	</tbody>
</table>

<p><strong>3. #Pragma Direktifi</strong><br />
Pragma direktifi iki şekilde kullanılır. #pragma inline Direktifi derleyiciye program i&ccedil;inde Assembler dil kodlarının bulunduğunu bildirir. İkinci kullanımda #Pragma warn -Uyari_Ismi Direktifi, programın derlenmesi aşamasında ismi verilen uyarıların dikkate alınmasını sağlar. Uyarı isimlerinden bazıları ve anlamları aşağıda verilmiştir.</p>

<table border="0" cellpadding="5" cellspacing="0" style="width:100%">
	<tbody>
		<tr>
			<td>Uyarı Ismi Anlamı
			<p>&nbsp;</p>

			<p><br />
			<strong>Big</strong>&nbsp;&ccedil;ok b&uuml;y&uuml;k onaltılık veya sekizlik sabit sayı&nbsp;<br />
			<strong>Dup</strong>&nbsp;ismin tekrar tanımlanmasında farklılık<br />
			<strong>Ret</strong>&nbsp;hem Return komutu hemde bir değerin geri d&ouml;n&uuml;ş&uuml; var<br />
			<strong>Str</strong>&nbsp;verilen isim bir yapının par&ccedil;ası değil<br />
			<strong>Stu</strong>&nbsp;tanımlanmamış isim yapısı<br />
			<strong>Sus</strong>&nbsp;ş&uuml;pheli pointer d&ouml;n&uuml;ş&uuml;m&uuml;<br />
			<strong>Voi</strong>&nbsp;Void fonksiyonlar bir değer g&ouml;nderemez<br />
			<strong>Zst</strong>&nbsp;sıfır uzunluktaki yapı<br />
			<strong>Aus</strong>&nbsp;hi&ccedil; kullanılmayan bir değer atandı.<br />
			<strong>Def</strong>&nbsp;tanımlanmadan &ouml;nce ismin kullanımı m&uuml;mk&uuml;n değil<br />
			<strong>Eff&nbsp;</strong>etkisiz ifade<br />
			<strong>Par</strong>&nbsp;ilgili parametre hi&ccedil;bir zaman kullanılamaz&nbsp;<br />
			<strong>Pia</strong>&nbsp;yanlış atama ihtimali<br />
			<strong>Rch</strong>&nbsp;ulaşılamayan kod<br />
			<strong>Rvi&nbsp;</strong>fonksiyonun bir değer g&ouml;ndermesi gerekir<br />
			<strong>Amb</strong>&nbsp;operat&ouml;rler parantezlerle kullanılmazlar.<br />
			<strong>Amp</strong>&nbsp;&amp; adres operat&ouml;r&uuml;n&uuml;n gereksiz kullanımı<br />
			<strong>Nod</strong>&nbsp;fonksiyon i&ccedil;in bir bildiri yok<br />
			<strong>Pro</strong>&nbsp;prototipsiz fonksiyon kullanımı<br />
			<strong>Stv</strong>&nbsp;yapısal değerin bir değer olarak ge&ccedil;işi<br />
			<strong>Use</strong>&nbsp;hi&ccedil;bir zaman kullanılmayan bildiri<br />
			<strong>Apt</strong>&nbsp;uygunsuz pointer ataması<br />
			<strong>Cln</strong>&nbsp;&ccedil;ok b&uuml;y&uuml;k sabit bir değer<br />
			<strong>Cpt</strong>&nbsp;uygunsuz pointer karşılaştırması<br />
			<strong>Rng</strong>&nbsp;karşılaştırmada sabit aralığın dışında&nbsp;<br />
			<strong>Sig&nbsp;</strong>d&ouml;n&uuml;ş&uuml;mde &ouml;nemli basamaklar kaybolabilir.<br />
			&nbsp;</p>
			</td>
		</tr>
	</tbody>
</table>

<p><br />
<strong>4. #Undef Direktifi</strong><br />
#Define ile tanımlanan bir isim, orijinal tanımlamaları kaldırılmaksızın farklı değerler i&ccedil;in tekrar tanımlanamazlar. Eğer #Define tanımlanan ifade başka bir değer ile tekrar tanımlanmak istenirse, ya program i&ccedil;inde #define ile tanımlanan ifade kaldırılıp yerine yenisi yazılır ya da #Undef direktifi ile &ouml;nceki tanımlama iptal edildikten sonra #Define ile tekrar yenisi tanımlanır.</p>
')
INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (4, N'<p>Yapımızın yapısını incelersek struct anahtar s&ouml;zc&uuml;ğ&uuml; ve &ouml;rnek adında bir yapı etiketi kullandık. Her yapı &lsquo;;&rsquo; ile bitmek zorundadır. Yapıların boyutu ise i&ccedil;indeki veri tiplerinin toplam boyu kadardır. int,float ve char veri tiplerimizin sırayla 2,4 ve 1 byte b&uuml;y&uuml;kl&uuml;ğ&uuml;nde bellekte yer kapladıklarını d&uuml;ş&uuml;nelim (Farklı derleyiciler de farklı temel veri tipi boyutuna rastlamak m&uuml;mk&uuml;n), o zaman struct &ouml;rnek adındaki veri tipimizin toplam boyutu 7 byte olacaktır. Not: Alignment kavramı g&ouml;z ardı edilerek 7 byte olacağı farzedilmiştir. Eğer alignment parametresi ile programımızı derlersek bir hizalama olacağı i&ccedil;in g&ouml;z &ouml;n&uuml;ne aldığımız sistemde 7byte yerine 8 byte yer kaplayacaktır. Alignment ger&ccedil;ekten programımızı hızlandıran bir se&ccedil;enek olarak karşımıza &ccedil;ıkar ve CPU nun daha az yorulmasını sağlar. Eğer yapımızı bir veri tipi olarak d&uuml;ş&uuml;n&uuml;rsek fonksiyonlara parametre olarak g&ouml;ndermek ve geri d&ouml;n&uuml;ş değeri kullanmak bizim i&ccedil;in daha da kolay bir hal alacaktır. Yapıların fonksiyonlarla kullanılmasına ve genel kullanımına ilişkin bir senaryo oluşturalım. Senaryomuz, iki tane farklı yapının farklı bellek b&ouml;lgelerine kopyalanması olacaktır ve bunu bir fonksiyon yardmıyla ger&ccedil;ekleyecektir.&nbsp;<br />
<br />
İlk &ouml;nce yapı tasarımımızı oluşturalım:<br />
&nbsp;</p>

<table border="0" style="width:100%">
	<tbody>
		<tr>
			<td>typedef struct{&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;char ad[15],&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;soyad[15];&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;int borc;&nbsp;<br />
			}kadir;</td>
		</tr>
	</tbody>
</table>

<p>Burada typedef anahtar kelimesi sayesinde uygulamamızda veri tipimizi kadir adında kullanabilmekteyiz. Yapımızın boyu 32 byte&rsquo;dır. Kullandığımız uygulamalarda direk hesaplamak yerine sizeof(kadir) veya sizeof(struct etiket_ismi) şeklinde de &ouml;ğrenebilriz.&nbsp;<br />
Fonksiyonumuz ise:<br />
&nbsp;</p>

<table border="0" style="width:100%">
	<tbody>
		<tr>
			<td>kadir *kopy(kadir *al){&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;rewind(stdin);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;puts(&quot;String gir&quot;);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;gets(al-&gt;ad);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;puts(&quot;2. String gir&quot;);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;gets(al-&gt;soyad);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;puts(&quot;rakam gir&quot;);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;scanf(&quot;%d&quot;,&amp;al-&gt;borc);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;return al;&nbsp;<br />
			}</td>
		</tr>
	</tbody>
</table>

<p><br />
Şeklinde olsun.Burada kopy adındaki fonksiyonumu parametre olarak kadir tipinden bir adres beklemektedir. kadir isimli veri tipimizi de typedef ile yapımız &uuml;zerinde tanımladık. Fonksiyonumuzun geri d&ouml;n&uuml;ş değeri ise yine kadir tipinden bir adres olacaktır. rewind(stdin) ile standart input&rsquo;umuzu geriye sardık. Ve puts fonksiyonları ile bir adres yazdırdık. Dikkat edilmesi gereken yer ise gets fonksiyonumuz parametre olarak yolladığımız kadir tipinden al adında değişkenin elemanlarına &lsquo;-&gt;&rsquo; işaretiyle ulaşıyoruz. Eğer işaret&ccedil;i &uuml;st&uuml;nden değil de direkt değer t&uuml;r&uuml;nden oluşturmuş olsaydık &lsquo;.&rsquo; İşaretiyle elemanlarımıza ulaşabilirdik(&Ouml;rnek: gets(al.ad); ) . scanf fonksiyonumuzun ise geleneksel olarak okuttuğumuz temel veri tiplerinden farklı bir yazım olarak sadece &amp;borc olması gereken yerde &amp;al-&gt;borc şeklinde yazılmıştır. Son olarak da kadir tipinden al adresini d&ouml;nd&uuml;r&uuml;yoruz. main fonksiyonumuz ise ş&ouml;yle olmalıdır:&nbsp;<br />
&nbsp;</p>

<table border="0" style="width:100%">
	<tbody>
		<tr>
			<td>int main(void)&nbsp;<br />
			{&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;kadir *x1;&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;kadir *x2;&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;clrscr();&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;x1=(kadir *)calloc(sizeof(kadir),5);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;x2=(kadir *)calloc(sizeof(kadir),5);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;for(int j=0;j&lt;5;++j) {&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*(x2+j)=*(kopy(x1+j));&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;for(int r=0;r&lt;5;++r){&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;puts((x2+r)-&gt;ad);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;puts((x2+r)-&gt;soyad);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;printf(&quot;%d&quot;,(x2+r)-&gt;borc);&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;getch();&nbsp;<br />
			&nbsp;&nbsp;&nbsp;&nbsp;return 0;&nbsp;<br />
			}</td>
		</tr>
	</tbody>
</table>

<p><br />
kadir tipinden iki adet işaret&ccedil;i tanımladık ve bunlara calloc fonksiyonu ile sizeof(kadir)*5 kadar yer aldık yani toplamda 5&rsquo;er adet yapımız i&ccedil;in yer a&ccedil;tık. Eğer sizeof() işlecini kullanmasaydık &lsquo;(kadir *)calloc(32,5);&rsquo; da diyebilirdik. Ardından for d&ouml;ng&uuml;m&uuml;z&uuml; 5 kere d&ouml;necek şekilde kurduk ve i&ccedil;inde kopy fonksiyonumuzu &ccedil;alıştırdık. x1+j adresini fonksiyona parametre olarak verdik(x1+0,x1+1,&hellip;x1+4 olarak parametreler gidecektir) ve geri d&ouml;n&uuml;ş değerimizi işaret&ccedil;i olduğu i&ccedil;in onun * operandıyla değerini *(x2+j) nin g&ouml;sterdiği adresinin değerine yerleştirmiş olduk.<br />
<br />
Not: Yapı işaret&ccedil;ilerinin 1 adres ileri gitmesi yapının boyu kadar olur. Diyelim yapımız 64 byte biz adresimizi bir arttırdığımızda 64 byte ileri gider. Veya 4 adres ileri gidersek 64*4 kadar yani 256 byte kadar ilerlemiş olur.<br />
Bu şekilde x1 adresimize bilgileri kopy fonksiyonuyla okuyup yine sırasıyla x2 ye yerleştirmiş olduk. Adresler hakkında ki bilgi ve RAM&rsquo;lerdeki yerleşimleri i&ccedil;in alttaki resmi inceleyebilrisiniz.&nbsp;</p>
')
INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (5, N'<p>Bu değişkenleri ne ama&ccedil;la kullanacağımıza kısaca değinelim. Uygulamamızda bir k&uuml;p oluşturacağız. OpenGL k&uuml;t&uuml;phanesi bu k&uuml;b&uuml;, sadece kenar &ccedil;izgileri ile g&ouml;sterebilmemize ya da y&uuml;zeylerini boyayarak g&ouml;sterebilmemize izin verir. filled isimli değişkeni de bu durumu belirlemek i&ccedil;in kullanacağız. Uygulamanın &ccedil;alışma zamanında, kullanıcı klavyeden f (fill) tuşuna basarak bu se&ccedil;eneği değiştirebilecek. Kullanıcı klavyeden t (turn) tuşuna bastığında şekil d&ouml;nd&uuml;r&uuml;lecek, tekrar t tuşuna bastığında ise şekil o anki a&ccedil;ısıyla sabit bi&ccedil;imde g&ouml;sterilecek. rotateAngle isimli değişken, şeklin d&ouml;nd&uuml;r&uuml;lme a&ccedil;ısını belirleyecek. xRotate, yRotate ve zRotate değişkenleri ise şeklin hangi eksenler etrafında d&ouml;nd&uuml;r&uuml;leceğini belirleyecek. D&ouml;nd&uuml;rme işlemini başlatmak veya durdurmak i&ccedil;in kullanıcı klavyeden t (turn) tuşuna basacak. D&ouml;nd&uuml;rme eksenlerini ayarlamak i&ccedil;in ise eksen isimlerini ifade eden x, y ve z tuşlarına basacak. xTranslate, yTranslate ve zTranslate değişkenleri, x, y ve z eksenleri boyunca yapılacak &ouml;teleme miktarını belirleyecek. Kullanıcı klavyeden l (left), r (right), u (up) ve d (down) tuşlarına bastık&ccedil;a bu değişkenlerin değerlerini değiştireceğiz. Dolayısıyla &ouml;teleme matrisinin değerlerini değiştirmiş olacağız.<br />
<br />
Uygulamamızda &ccedil;izim işlemlerini yaptığımız fonksiyon DrawGLScene isimli fonksiyon idi. Uygulamanın &ccedil;alışma zamanında herhangi bir mesaj alınmadığı s&uuml;rece bu fonksiyon &ccedil;ağrılır ve ekrana &ccedil;izim işlemi yapılır. DrawGLScreen fonksiyonunun hemen ardından SwapBuffers isimli fonksiyon &ccedil;ağılır ve g&ouml;r&uuml;nt&uuml; tamponundaki değişiklikler ekrana yansıtılır. Bu uygulamada DrawGLScreen isimli fonksiyonun i&ccedil;eriğini değiştireceğiz. Ekrana &ouml;nce yapılacak değişikliklerin daha iyi anlaşılması i&ccedil;in x, y ve z eksenlerini belirten bir koordinat sistemi &ccedil;izdireceğiz, ardından bir k&uuml;p &ccedil;izdireceğiz. Şimi DrawGLScreen fonksiyonumuzu inceleyelim :</p>
')
INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (6, N'<p>Başlık kısa ancak konu olduk&ccedil;a uzun. 2000&#39;lerin başından beri var olmasına rağmen T&uuml;rkiye&#39;deki .Net camiasında yurtdışındaki kadar pop&uuml;ler olmayan ancak en g&uuml;&ccedil;l&uuml; O/RM se&ccedil;eneklerinden biri olan NHibernate ile ilgili hızlı bir tanıtım yazısı okumak &uuml;zeresiniz.</p>

<h3>O/RM (Object Relational Mapping) mi?</h3>

<p>Ka&ccedil;ınız şimdiye veri depolama ihtiyacı olmayan bir uygulama geliştirdi? Eğer yazılım ge&ccedil;mişiniz benim gibi Commodore ve Amstrad d&ouml;nemlerine kadar uzanmıyorsa bu soruya &quot;ben&quot; şeklinde cevap vermenizin d&uuml;ş&uuml;k bir ihtimal olduğunu d&uuml;ş&uuml;n&uuml;yorum.</p>

<p>Geliştirdiğimiz her yazılımda bir şekilde bir yerde veri depolama ihtiyacı duyuyoruz. XML dosyalarından, ilişkisel veritabanlarına kadar veri depolamak i&ccedil;in bir&ccedil;ok alternatif mevcut. Bu bir&ccedil;ok alternatife erişip veri &uuml;zerinde işlem yapmak i&ccedil;in yine bir&ccedil;ok farklı teknoloji mevcut. .Net d&uuml;nyasında olan bir&ccedil;ok yazılım ekibi genelde bu alternatifler i&ccedil;inden Ado.Net&#39;i, dolayısıyla DataSet, DataReader vb. nesneleri kullanmayı tercih ediyor. Tabi ki bunda yanlış olan hi&ccedil;bir şey yok. Ancak durum biraz daha farklı. Ş&ouml;yle ki;</p>

<h3>Herşeyi nesnelerle d&uuml;ş&uuml;n&uuml;r, nesne olarak değerlendiririz.</h3>

<p>Yani bir topluluk portali uygulaması geliştiriyorsak, &quot;&Uuml;ye&quot;lerden, &quot;Paylaşım&quot;lardan, &quot;Yorum&quot;lardan vb. bir&ccedil;ok nesneden / varlıktan bahsediyoruz demektir. Ya da bir bankacılık uygulaması ise geliştirdiğimiz, Hesap, M&uuml;şteri, Para Transferi, Kredi Kartı gibi nesnelerdir uygulamamızın kapsamını oluşturan. Bu kapsama ilgi alanı (domain), bu kapsam i&ccedil;inde yukarıda bahsettiğimiz her nesneye de ilgi alanı modeli (domain model) ismi verilmektedir. &Ccedil;&ouml;z&uuml;m gerektiren her problemin adreslendiği yer ilgi alanı modeli olmalıdır. Kredi Kartı numaralarının doğruluğunun kontrol&uuml;, hesap bakiyesi belli bir miktarın &uuml;st&uuml;nde olan m&uuml;şterinin &quot;gold&quot; m&uuml;şteri olarak değerlendirilmesi gibi &quot;iş&quot; ile ilgili her durum bu ilgi alanı i&ccedil;erisinde modellenir.</p>

<p>Bu modelleme s&uuml;reci, modellerin veri depolarında saklanma aşamasına gelindiğinde başka bir ihtiyacın ortaya &ccedil;ıkmasına neden olur. .Net &uuml;zerinden ilerleyecek olursak, programlama dilinde &quot;sınıf&quot; olan bu modeller, veri saklama ortamlarına aktarılırken tablolara, daha doğrusu tabloları oluşturan kayıtlara d&ouml;n&uuml;şt&uuml;r&uuml;lmelidirler. Yani kendi i&ccedil;inde her t&uuml;r durumun (ya da daha ger&ccedil;ek&ccedil;i olması a&ccedil;ısından bir&ccedil;ok durumun diye d&uuml;zeltelim) değerlendirildiği bir sınıfın depoladığı verinin alınması, ilişkisel veritabanının anlayabileceği, saklayabileceği formata d&ouml;n&uuml;şt&uuml;r&uuml;lmesi ve depolanması gereklidir. Eğer şimdiye kadar anlattığım gibi bir ilgi alanı modeli geliştiriyorsanız ve ilgi alanı i&ccedil;indeki modellerinizin verisini &ouml;rneğin SQL Server&#39;da saklamak i&ccedil;in gerekli olan d&ouml;n&uuml;ş&uuml;m kodlarını yazıyorsanız tebrik ederim, siz bir O/RM geliştiricisi olmuşsunuz bile.</p>

<p>Wikipedia&#39;dan alınmış tam tanımı ile,&nbsp;<em>O/RM, nesne y&ouml;nelimli programlama dillerinde uygulanan, birbirleriyle uyumsuz tip sistemleri arasında, verinin uyumlu hale getirilmesi tekniğidir</em>. Bu tanımı bizim anlatımımıza uyarlayacak olursak; .Net ile SQL Server tabloları birbirleriyle uyumsuz tip sistemleridir ve bizim, nesnelerden aldığımız her veriyi SQL Server uyumlu hale getirmek i&ccedil;in yazdığımız her satır kod O/RM tekniğine işaret eden bir koddur diyebiliriz.</p>

<p>NHibernate&#39;in yukarıdaki anlatımda tam olarak nereye oturduğu sanırım anlaşılmıştır. NHibernate bir O/RM &ccedil;atısı. .Net ile yazdığımız sınıfların, ilişkisel veritabanı sistemleri ile eşleştirmesini (d&ouml;n&uuml;şt&uuml;r&uuml;lmesini) ger&ccedil;ekleştiriyor. Daha g&uuml;zel bir ifadeyle, biz ilgi alanımıza ve iş kurallarımıza yoğunlaşırken, ilgi alanı modelimizin veritabanı ile ilgili olan kısmındaki t&uuml;m ağır işi NHibernate y&uuml;kleniyor.</p>

<h3>O/RM&#39;nin M&#39;si</h3>

<p>NHibernate, sınıfların ilişkisel veritabanı ile eşleştirilmesini sağlıyor demiştik. O halde bu eşleştirmenin nasıl yapılması gerektiğini de NHibernate&#39;e g&ouml;stermek gerekiyor. Modellerin hangi &ouml;zellikleri, veritabanında hangi kolon ile eşleşecek, modelin hangi &ouml;zelliği eşlenen tablodaki anahtar kolon olacak, modeller arasındaki ilişkiler veritabanına ne şekilde yansıtılacak vb. gibi t&uuml;m eşleme kurallarının NHibernate tarafından bilinmesi gerekiyor.</p>

<p>Eşleme kurallarının tanımlanması i&ccedil;in kullanılabilecek iki y&ouml;ntem mevcut. Birinci y&ouml;ntem -ki bu en eski ve yaygın olan y&ouml;ntemdir- hbm.xml uzantılı bir xml konfig&uuml;rasyon dosyası ile eşleme kurallarını belirlemek. İkinci y&ouml;ntem NHibernate ile kardeş proje olan Fluent NHibernate kullanarak ger&ccedil;ekleştirilen eşleme ger&ccedil;ekleştirmek. Xml konfig&uuml;rasyon dosyalarını her zaman sıkıcı ve itici bulmuşumdur, dolayısıyla bu yazıda Fluent kullanarak eşlemeleri ger&ccedil;ekleştireceğim.</p>

<h3>İlgi Alanı Modeli</h3>

<p>Fluent NHibernate i&ccedil;inde hazır gelen &ouml;rnek proje &uuml;zerinden ilerleyeceğiz. Yazının sonunda projeyi indirebileceğiniz web adresini paylaştım. Yazı i&ccedil;erisinde yapacağım k&uuml;&ccedil;&uuml;k değişiklikleri kolayca projeye uyarlayabilirsiniz. Projedeki modellerin yapısı şu şekilde:</p>

<p><img alt="image" src="http://www.csharpnedir.com/articles/images/onsel_akin/01_734008.jpg" style="height:387px; width:564px" /></p>

<p>İlgi alanı i&ccedil;inde d&ouml;rt model mevcut. &Ouml;zellikleri şemada g&ouml;rd&uuml;ğ&uuml;n&uuml;z gibi. Modelde &uuml;zerinde durulması gereken şey sınıflar arasındaki ilişkiler. Store ve Product sınıfları arasında &ccedil;oka-&ccedil;ok (many-to-many) ilişki mevcut. Yani bir mağazada birden &ccedil;ok &uuml;r&uuml;n bulunabilir ve bir &uuml;r&uuml;n bir&ccedil;ok mağaza stoğunda mevcut olabilir. Ayrıca Store ve Employee sınıfları arasında bire-&ccedil;ok (one-to-many) ilişki mevcut. Yani bir mağazada birden &ccedil;ok &ccedil;alışan bulunabilir. Product ve Location sınıfları arasında ise biraz daha farklı bir ilişki mevcut. Bu iki sınıf arasında bir bileşim (composition) ilişkisi tanımlı. Yani &uuml;r&uuml;n&uuml;n depodaki koridor ve raf numarasını g&ouml;stermekte olan Location sınıfı her &uuml;r&uuml;n&uuml;n mutlaka sahip olması gereken bir bileşen. Modeli kullanırken koridor ve raftan oluşan bu lokasyon nesnesine tek başına bir varlıkmış gibi erişebileceğiz ancak ilişkisel veritabanı a&ccedil;ısından bakıldığında Location nesneleri i&ccedil;in ayrı bir veritabanı tablosu oluşturulmayacak. Bunun yerine, Location sınıfına ait olan Aisle ve Shelf &ouml;zellikleri, sanki Product sınıfının doğrudan &ouml;zellikleriymiş gibi Product tablosunda iki ayrı kolon olarak tanımlanacak ve bu kolonlarda bilgi depolanacak.</p>
')
INSERT INTO [dbo].[PostDetails] ([PostId], [PostText]) VALUES (1002, N'<p>SharePoint 2010 ile gelen &ccedil;ok şık ve g&ouml;rsel bir tasarım şablonu bulunmaktadır. Fakat tahmin edebileceğiniz &uuml;zere şirket ve kişi bazlı olarak tasarımların d&uuml;zenlenmesinin gerekli olduğu durumların ortaya &ccedil;ıkması m&uuml;mk&uuml;nd&uuml;r. &Ouml;zellikle de kurumsal firmalara hazırlamış olduğumuz SharePoint 2010 projelerinin tasarımlarının &ouml;ncelikli olarak şirlet şablonuna uyumlu bir hale getirilip ondan sonra &ccedil;alışılması devam etmek gerekir. Peki bu t&uuml;r işlem yapmanın ne t&uuml;r bir gereksinimleri olur konusuna gelirsek. Bunu iki y&ouml;nden inceleyebiliriz. Birinci olarak k&uuml;&ccedil;&uuml;k ve orta &ouml;l&ccedil;ekli geliştirilen projeleri ele alalım. İlk olarak alt siteler ve sayfalar bazında belirli bir stilin ve tasarımın olması son kullanıcı &uuml;zerinde olduk&ccedil;a iyi bir izlenim bırakmaktadır. Ayrıca orta ve k&uuml;&ccedil;&uuml;k &ouml;l&ccedil;ekli projelerin insanların g&ouml;z&uuml;nde daha değerli g&ouml;r&uuml;nebilmesi amacıyla ve profesyonel bir izlenim olabilmesi a&ccedil;ısında tasarımın &ouml;zel ve sabit olmasında kesinlikle &ouml;nem payı vardır.</p>

<p><br />
İkinci olarak b&uuml;y&uuml;k &ouml;l&ccedil;ekli yani kurumsal firmalarda ise zaten genel anlamda kullandıkları hazır şablonları olduklarından bunun SharePoint i&ccedil;erisine uyarlanması gerekecektir. &Ccedil;&uuml;nk&uuml; yine profesyonel kullanım a&ccedil;ısından &ouml;nemi vardır.<br />
<br />
Bu kadar bilgiyi neden anlattığımıza gelirsek, tahmin edebileceğiniz &uuml;zere SharePoint &lsquo;in varsayılan MasterPage &lsquo;ini ve sayfalarını d&uuml;zenlemek olduk&ccedil;a &ouml;nemli bir s&uuml;re&ccedil; olarak yer almaktadır. Biz de bu yazımızda basit&ccedil;e nasıl gerekli d&uuml;zenleme işlemlerini yapabileceğimizi anlatmaya &ccedil;alışacağız.<br />
<br />
&Ouml;ncelikle SharePoint &lsquo;in Server &lsquo;da ya da Windows 7 işletim sisteminde deploy ediyor olmamız i&ccedil;in kurulu olması gerekmektedir. Sonrasında tasarım işlemlerini yapabilmek amacıyla sistemimizde kurulu olan Office Microsoft 2010 sistemin kurulu olan işlemci tipine bağlı olarak SharePoint Designer 2010 &uuml;r&uuml;n&uuml;n&uuml; de kurmak gerekecektir. Bu &uuml;r&uuml;n yerine Visual Studio kullanmamazdıydık diye bir sou gelebilir aklınıza. Ancak SharePoint &lsquo;in tasarımsal &ouml;ğelerini ve MasterPage &lsquo;ini en iyi g&ouml;r&uuml;nt&uuml;leyebilmemiz a&ccedil;ısında olduk&ccedil;a &ouml;nem teşkil etmektedir.<br />
<br />
Bu durumda ilk olarak SharePoint 2010 &lsquo;un bi varsayılan tasarımına g&ouml;z atıyor olalım.&nbsp;</p>
')
