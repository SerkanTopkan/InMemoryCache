# Net. Core Projelerinde In-Memory Cache Kullanımı

Geliştirdiğimiz uygulamaları kullanan kişi sayısı arttıkça yavaşlık kaçınılmaz hale geliyor. Bu da müşteri memnuniyetsizliği ile beraber kullanıcı kaybına neden oluyor. Tüm bunların özelinde yavaşlığın büyük oranda önüne geçebilecek “Caching Yöntemi” ni kullanmak yazılımcılar için büyük önem taşıyor.


Caching basit tabirle, sık kullanılan dataları kaydetme tekniğine verilen isimdir. Kayıt işlemi iki yöntem ile gerçekleştirilebilir.

**In-Memory Caching**

**Distributed Caching**

Bu örnekte sizlere "In-Memory Caching" kavramını ve NET Core üzerinde nasıl kullanıldığını anlatmaya çalışacağım.

## In-Memory Caching Nedir ?
Uygulamayla ilgili dataların , uygulamayı barındıran web Server’ın “RAM” ine yani “Memory”sine kaydedilme işlemine denir.

**Cache Metodolojileri**

**On-Demand**: Bir datanın sadece talep edildiği anda cache’lenmesine denir.

**Prepopulation**: Uygulama ayağa kalkar kalkmaz cache’lenme olayına denir.

**Cache Ömrü**

**Absolute Time**: Cache oluşturulduktan sonra verilme süresi yani Memory’de kalma süresidir. Verilen süre dolduğunda veri cache’den silinir.
**Sliding Time**: Memory’de ne kadar inaktif kalacağını belirtiriz. Verilen süre içerisinde cache verisine erişilirse, Cache in süresi siliding time süresi kadar daha uzatılmış olur. Tek başına kullanılırsa bayat (eski) dataya ulaşılabilir. Bunun önünce geçmek için Absolute Time ile birlikte verilmesi gerekir.

Uygulama içine yapacaklarımız :

 - In-Memory Cache Servisini Core projesinde ayağa kaldıracağız.
 - Kullanacağımız Katmana Inject işlemi yapacağız.
 - IMemoryCache - Get() ve set() methodunun Kullanımı
- IMemory Cache - Remove Kullanımı
- Absolute Expiration ve Sliding Expiration
- Cache Priority
- Complex Types Caching (class yapılarının cachlenmesi)
