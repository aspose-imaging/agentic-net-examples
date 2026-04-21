using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (FileStream inputZipStream = new FileStream(inputZipPath, FileMode.Open, FileAccess.Read))
            using (System.IO.Compression.ZipArchive inputArchive = new System.IO.Compression.ZipArchive(inputZipStream, System.IO.Compression.ZipArchiveMode.Read))
            using (FileStream outputZipStream = new FileStream(outputZipPath, FileMode.Create, FileAccess.ReadWrite))
            using (System.IO.Compression.ZipArchive outputArchive = new System.IO.Compression.ZipArchive(outputZipStream, System.IO.Compression.ZipArchiveMode.Create))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in inputArchive.Entries)
                {
                    if (string.IsNullOrEmpty(entry.Name))
                        continue;

                    using (Stream entryStream = entry.Open())
                    using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(entryStream))
                    {
                        int width = image.Width;
                        int height = image.Height;

                        StreamSource overlaySource = new StreamSource(new MemoryStream());
                        PngOptions overlayOptions = new PngOptions() { Source = overlaySource };
                        using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(overlayOptions, width, height))
                        {
                            int[] pixels = new int[width * height];
                            int argb = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0).ToArgb();
                            for (int i = 0; i < pixels.Length; i++) pixels[i] = argb;

                            overlay.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), pixels);
                            image.Blend(new Aspose.Imaging.Point(0, 0), overlay, (byte)128);
                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, new PngOptions());
                            ms.Position = 0;

                            System.IO.Compression.ZipArchiveEntry outEntry = outputArchive.CreateEntry(entry.FullName);
                            using (Stream outStream = outEntry.Open())
                            {
                                ms.CopyTo(outStream);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}