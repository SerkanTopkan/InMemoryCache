using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld
{

    class Program
    {

        static void Main(string[] args)
        {
            var host = new ServiceCollection()
                         .AddMemoryCache()
                         .BuildServiceProvider();

            using (IMemoryCache cache = host.GetService<IMemoryCache>())
            {
                //Eğer cache yok ise
                if (!cache.TryGetValue("dateTime", out DateTime dateTime))
                {
                    MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();

                    //Absolute Time: Cache oluşturulduktan sonra verilme süresi yani Memory’de kalma süresidir. Verilen süre dolduğunda veri cache’den silinir.
                    options.AbsoluteExpiration = DateTime.Now.AddSeconds(10);

                    //Sliding Time: Memory’de ne kadar inaktif kalacağını belirtiriz. Verilen süre içerisinde cache verisine erişilirse, Cache in süresi siliding time süresi kadar daha uzatılmış olur. Tek başına kullanılırsa bayat(eski) dataya ulaşılabilir. Bunun önünce geçmek için Absolute Time ile birlikte verilmesi gerekir.
                    options.SlidingExpiration = TimeSpan.FromSeconds(10);

                    options.Priority = CacheItemPriority.High;
                    //High : Ram dolarsa en son bunu sil 
                    //Low : Ram dolarsa ilk bunu sil 
                    //NeverRemove : Ram dolsa da silme Not: Exception'a düşme ihtimali var Ram dolarsa
                    //Normal : High ile Low arasında

                    cache.Set<DateTime>("dateTime", DateTime.Now, options);
                }
                //İki kez yazdırıyorum
                //10 saniye boyunca aynı tarihi almış olacağım.
                Console.WriteLine(cache.Get<DateTime>("dateTime"));
                Console.WriteLine(cache.Get<DateTime>("dateTime"));

                cache.Remove("dateTime");
                //Cache temizliği yaptığım için burada 1.01.0001 00:00:00 basacak
                Console.WriteLine(cache.Get<DateTime>("dateTime"));


            }



        }
    }
}
