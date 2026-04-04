using System;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        int width = 100;
        int height = 50;

        ImageBitMask mask1 = new ImageBitMask(width, height);
        for (int y = 10; y < 20; y++)
        {
            for (int x = 10; x < 30; x++)
            {
                mask1.SetMaskPixel(x, y, true);
            }
        }

        ImageBitMask mask2 = new ImageBitMask(width, height);
        for (int y = 10; y < 20; y++)
        {
            for (int x = 20; x < 40; x++)
            {
                mask2.SetMaskPixel(x, y, true);
            }
        }

        ImageBitMask unionMask = mask1.Union(mask2);

        bool onlyMask1 = unionMask.IsOpaque(15, 15);
        bool onlyMask2 = unionMask.IsOpaque(35, 15);
        bool overlap = unionMask.IsOpaque(25, 15);
        bool outside = unionMask.IsOpaque(5, 5);

        Console.WriteLine($"Only mask1 area opaque: {onlyMask1}");
        Console.WriteLine($"Only mask2 area opaque: {onlyMask2}");
        Console.WriteLine($"Overlap area opaque: {overlap}");
        Console.WriteLine($"Outside area transparent (should be false): {outside}");
    }
}