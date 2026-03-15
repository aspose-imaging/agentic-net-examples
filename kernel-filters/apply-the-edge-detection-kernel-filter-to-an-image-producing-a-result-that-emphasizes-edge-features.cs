using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output_edge.png";

        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath);
        }
    }
}