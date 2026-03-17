using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Configure cache (optional but useful for monitoring)
        Cache.CacheType = CacheType.Auto;
        Cache.MaxMemoryForCache = 200 * 1024 * 1024; // 200 MB memory limit for cache

        // Set up image creation options with a buffer size hint (limits internal buffers)
        var createOptions = new PngOptions
        {
            Source = new FileCreateSource("output.png", false),
            BufferSizeHint = 30 // limit internal buffers to 30 MB
        };

        // Create a large image while respecting the memory limit
        using (var image = Image.Create(createOptions, 4000, 4000) as RasterImage)
        {
            // Perform drawing operations within the established memory constraints
            var graphics = new Graphics(image);
            graphics.Clear(Color.LightSkyBlue);
            graphics.DrawLine(new Pen(Color.Red, 2f), 0, 0, image.Width, image.Height);

            // Save the image using the provided save rule
            image.Save();
        }

        // After disposing the image, inspect cache usage to verify memory release
        long memoryBytes = Cache.AllocatedMemoryBytesCount;
        long diskBytes = Cache.AllocatedDiskBytesCount;
        Console.WriteLine($"Memory cache allocated: {memoryBytes} bytes");
        Console.WriteLine($"Disk cache allocated: {diskBytes} bytes");
    }
}