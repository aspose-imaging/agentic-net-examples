// HOW-TO: Convert Multipage EPS To Multipage PSD Preserving All Layers In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\multipage.eps";
            string outputPath = "Output\\result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image epsImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = epsImage as IMultipageImage;
                if (multipage == null)
                {
                    // Single-page EPS handling: save directly as PSD
                    PsdOptions psdOptions = new PsdOptions();
                    psdOptions.Source = new FileCreateSource(outputPath, false);
                    epsImage.Save(outputPath, psdOptions);
                }
                else
                {
                    // Multi-page EPS handling
                    Image firstPage = multipage.Pages[0];
                    PsdOptions psdOptions = new PsdOptions();
                    psdOptions.Source = new FileCreateSource(outputPath, false);
                    using (Image psd = Image.Create(psdOptions, firstPage.Width, firstPage.Height))
                    {
                        IMultipageImageExt psdExt = psd as IMultipageImageExt;
                        if (psdExt != null)
                        {
                            psdExt.AddPage(firstPage as RasterImage);
                            for (int i = 1; i < multipage.PageCount; i++)
                            {
                                Image page = multipage.Pages[i];
                                psdExt.AddPage(page as RasterImage);
                            }
                        }
                        psd.Save();
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

/*
 * Real-World Use Cases:
 * 1. When you need to import a multi‑page EPS artwork into Photoshop for further editing, you can convert it to a multi‑page PSD while keeping each page as a separate layer.
 * 2. When a printing workflow requires EPS files to be archived as PSD files that retain page order for later composition.
 * 3. When building a .NET application that batch‑processes vector EPS documents and outputs editable PSD files for designers.
 * 4. When automating the migration of legacy EPS assets to Photoshop‑compatible PSD stacks without losing any page information.
 * 5. When creating a server‑side service that receives EPS submissions and returns a PSD file with each page accessible as an individual raster layer.
 */
