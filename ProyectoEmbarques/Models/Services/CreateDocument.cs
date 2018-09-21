﻿using Editing = Telerik.Windows.Documents.Fixed.Model.Editing;
using FontStyles = System.Windows.FontStyles;
using FontWeights = System.Windows.FontWeights;
using Size = System.Windows.Size;
using Point = System.Windows.Point;
using Rect = System.Windows.Rect;
using System.IO;
using System.Linq;
using Telerik.Windows.Documents.Fixed.Model.Editing.Tables;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.ColorSpaces;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.Model.Editing.Flow;
using Telerik.Windows.Documents.Fixed.Model.Fonts;
using System.Windows.Media;
using ProyectoEmbarques.Models;
using System.Diagnostics;
using ProyectoEmbarques.Models.Services;

namespace ProyectoEmbarques
{
    public class CreateDocument
    {
        private static readonly double MargenIzquierdo = 50;
        private static readonly double AnchoDeLinea = 12;//Alto por defecto de la linea (de texto?)
        public static RadFixedDocument CreatePDFDocument(decimal ParametroFedex)
        {
            RadFixedDocument document = new RadFixedDocument();
            RadFixedPage page = document.Pages.AddPage();

            page.Size = new Size(600, 800);
            double maxWidth = page.Size.Width - MargenIzquierdo * 2;//Establece el tamano de ancho maximo multiplicando el valor de Ident izquierdo por dos y restandole esta cantidad al ancho total de pagina

            FixedContentEditor editor = new FixedContentEditor(page);//Se declara el editor de la pagina 

            DrawDescription(editor, maxWidth);
            DrawData(editor, maxWidth, ParametroFedex);
            //DrawTable(editor, maxWidth);
            Footer(editor, maxWidth);
            return document;
        }
       
        private static void DrawDescription(FixedContentEditor editor, double maxWidth)
        {
            double WriteWhere = 20;//Define el actual tope del editor en 500
            editor.Position.Translate(MargenIzquierdo + 300, WriteWhere);//Traslada el editor al nuevo punto de escritura

            using (FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/Images/LogoBae.jpeg"), FileMode.Open, FileAccess.Read))
            { editor.DrawImage(fs); }
            Block block = new Block();

            WriteWhere += AnchoDeLinea * 4;
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura
            block.InsertText("BAE SYSTEMS");
            block.TextProperties.Font = FontsRepository.Helvetica;
            block.TextProperties.FontSize = 14;
            editor.DrawBlock(block);
            block = new Block();
            editor.Position.Translate(450, WriteWhere);//Traslada el editor al nuevo punto de escritura
            using (block.SaveTextProperties())
            {
                block.TextProperties.Font = FontsRepository.CourierBold;
                block.InsertText(new FontFamily("Calibri"), "DATE: ");
            }
            block.InsertText(new FontFamily("Calibri"), System.DateTime.Now.ToShortDateString());
            editor.DrawBlock(block);
            WriteWhere += AnchoDeLinea * 2;
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura

            block = new Block();
            block.InsertText("Carretera Internacional KM.129 Salida");
            editor.DrawBlock(block);
            WriteWhere += AnchoDeLinea * 1.5;
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura

            block = new Block();
            block.InsertText("Norte Parque Industrial Roca Fuerte");
            editor.DrawBlock(block);
            WriteWhere += AnchoDeLinea * 1.5;
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura

            block = new Block();
            block.InsertText("Edificio#19 Guaymas Sonora, Mexico");
            editor.DrawBlock(block);
            WriteWhere += AnchoDeLinea * 2;
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura
        }

        private static void DrawData(FixedContentEditor editor, double maxWidth, decimal ParametroFedex)
        {
            MaterialShippingControlEntities BD = new MaterialShippingControlEntities();
            double WriteWhere = 160;//Define el actual tope del editor

            Block block = new Block();//Declara un nuevo bloque
                                      //SaltoLinea

            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Mueve ele editor

            using (block.SaveTextProperties())
            {
                block.TextProperties.Font = FontsRepository.CourierBold;
                block.InsertText(new FontFamily("Calibri"), "Fedex Tracking: ");
            }
            block.InsertText(new FontFamily("Calibri"), ParametroFedex.ToString());
            editor.DrawBlock(block);

            //SaltoLinea
            WriteWhere += AnchoDeLinea * 2;//Salto de linea al editor
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Mueve ele editor
            try
            {
                var x = (from b in BD.Shipping_Records
                         where b.RecordFedexTracking == ParametroFedex
                         select new ClientesViewModel
                         {
                             ClientName = b.Clients.ClientName
                         }).FirstOrDefault();

                block = new Block();//Declara un nuevo bloque

                using (block.SaveTextProperties())
                {
                    block.InsertText(new FontFamily("Calibri"), "Reference: ");
                }
                    block.InsertText(new FontFamily("Calibri"), x.ClientName.ToString());
                    editor.DrawBlock(block);
            }
                catch (System.Exception)
            {
                throw;
            }
            //SaltoLinea
            block = new Block();//Declara un nuevo bloque
            WriteWhere += AnchoDeLinea * 3;//Salto de linea al editor
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Mueve ele editor
            block.InsertText("FINISH PRODUCT: SHIPMENTS TO THE UNITED STATES PACKING LIST");
            block.TextProperties.Font = FontsRepository.Helvetica;
            block.TextProperties.FontSize = 14;
            editor.DrawBlock(block);

            WriteWhere += AnchoDeLinea * 2;//Salto de linea al editor
            editor.Position.Translate(50, WriteWhere);//Mueve ele editor

            RgbColor headerColor = new RgbColor(196, 196, 196);//Color de Header
            RgbColor bordersColor = new RgbColor(255, 255, 255);//Color de los bordes
            RgbColor alternatingRowColor = new RgbColor(224, 224, 224);//Color de rows
            Border border = new Border(1, Editing.BorderStyle.Single, bordersColor);//Estilo de borde

            Table table = new Table
            {
                Borders = new TableBorders(border),//A la propiedad borders de la tabla se le agrega el estilo de borde creado 
                LayoutType = TableLayoutType.FixedWidth//Tipo de dise;o
            };//Nuevo objeto tabla
            table.DefaultCellProperties.Borders = new TableCellBorders(border, border, border, border);//Bordes de la tabla se les da las propiedades del objeto borde
            table.DefaultCellProperties.Padding = new System.Windows.Thickness(2);//Padding de tabla

            TableRow NewFila = table.Rows.AddTableRow();//Nuevo objeto TableRow se anade a la tabla
            
            /////////////////////////////////////////////////////////////////////Contenido de la tabla///////////////////////////////////////////

            TableCell ObjetoCelda = NewFila.Cells.AddTableCell();//Objeto TableCell se anade a la tabla como fila
            ObjetoCelda.PreferredWidth = 100;
            ObjetoCelda.Background = headerColor;//A partir de ahora se declaran celdas que se agregaran al row
            Block ObjetoBlock = ObjetoCelda.Blocks.AddBlock();//Declara un objeto de clase Block
            ObjetoBlock.TextProperties.FontSize = 12;
            ObjetoBlock.HorizontalAlignment = HorizontalAlignment.Center;//Le da la alineacion
            ObjetoBlock.VerticalAlignment = VerticalAlignment.Center;
            ObjetoBlock.InsertText("PACKAGING INFORMATION");//Agrega el texto de la primera columna
            
            ////----------SegundaColumna
            TableCell ObjetoCelda2 = NewFila.Cells.AddTableCell();//Objeto TableCell se anade a la tabla como fila
            ObjetoCelda2.Background = headerColor;//Toma el color de fondo
            ObjetoCelda2.PreferredWidth = 250;
            Block ObjetoBlock2 = ObjetoCelda2.Blocks.AddBlock();//Declara un objeto de clase Block
            ObjetoBlock2.TextProperties.FontSize = 12;
            ObjetoBlock2.HorizontalAlignment = HorizontalAlignment.Center;//Le da la alineacion
            ObjetoBlock2.VerticalAlignment = VerticalAlignment.Center;
            ObjetoBlock2.InsertText("PART NUMBER");//Le agrega el texto en el formato dado 

            ////----------TerceraColumna
            TableCell ObjetoCelda3 = NewFila.Cells.AddTableCell();//Objeto TableCell se anade a la tabla como fila
            ObjetoCelda3.Background = headerColor;//Toma el color de fondo
            ObjetoCelda3.PreferredWidth = 100;
            Block ObjetoBlock3 = ObjetoCelda3.Blocks.AddBlock();//Declara un objeto de clase Block
            ObjetoBlock3.TextProperties.FontSize = 12;
            ObjetoBlock3.VerticalAlignment = VerticalAlignment.Center;
            ObjetoBlock3.HorizontalAlignment = HorizontalAlignment.Center;//Le da la alineacion
            ObjetoBlock3.InsertText("QUANTITY SHIPPED");//Le agrega el texto en el formato dado 

                IQueryable<Shipping_RecordsViewModel> select = (from b in BD.Shipping_Records
                              where b.RecordFedexTracking==ParametroFedex
                              select new Shipping_RecordsViewModel()
                              {
                                  RecordPieceBoxNo = b.RecordPieceBoxNo,
                                  Shipping_Catalog_Products = new Shipping_Catalog_ProductsViewModel()
                                  {
                                      ProductName=b.Shipping_Catalog_Products.ProductName
                                  },
                                    RecordQuantity = b.RecordQuantity
                              });

                int i = 0;
                foreach (var sel in select)
                {
                    i++;
                    TableRow FilaContent = table.Rows.AddTableRow();//Nuevo objeto TableRow se anade a la tabla
                    RgbColor rowColor = i % 2 == 0 ? alternatingRowColor : RgbColors.White;// Alterna el color de la tabla obteniendo el residuo de la variable del ciclo 

                    //1erCampo
                    TableCell ObjetoContenido = FilaContent.Cells.AddTableCell();//Objeto TableCell se anade a la tabla como fila
                    ObjetoContenido.Background = rowColor;//Toma el color de fondo

                    Block amountBlock = ObjetoContenido.Blocks.AddBlock();
                    amountBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    amountBlock.InsertText(sel.RecordPieceBoxNo.ToString());

                    //SegundoCampo
                    TableCell ObjetoContenido2 = FilaContent.Cells.AddTableCell();//Objeto TableCell se anade a la tabla como fila
                    ObjetoContenido2.Background = rowColor;//Toma el color de fondo

                    Block amountBlock2 = ObjetoContenido2.Blocks.AddBlock();
                    amountBlock2.HorizontalAlignment = HorizontalAlignment.Center;
                    amountBlock2.InsertText(sel.Shipping_Catalog_Products.ProductName);

                    //3er Campo
                    TableCell ObjetoContenido3 = FilaContent.Cells.AddTableCell();//Objeto TableCell se anade a la tabla como fila
                    ObjetoContenido3.Background = rowColor;//Toma el color de fondo

                    Block amountBlock3 = ObjetoContenido3.Blocks.AddBlock();
                    amountBlock3.HorizontalAlignment = HorizontalAlignment.Center;
                    amountBlock3.InsertText(sel.RecordQuantity.ToString());
                }
            ////////////////////////////////////////////////////////////////////Contenido de la tabla///////////////////////////////////////////
            editor.DrawTable(table);
        }

        private static void Footer(FixedContentEditor editor, double maxWidth)
        {
            double WriteWhere =650;
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura

            Block block = new Block();
            block.TextProperties.Font = FontsRepository.TimesRoman;
            block.TextProperties.FontSize = 13;
            block.InsertText("Certificate of Conformance Statement");

            editor.DrawBlock(block);

            WriteWhere += AnchoDeLinea * 1.5;//Salto de linea al editor
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura

            block = new Block();
            block.TextProperties.FontSize = 13;
            block.InsertText(new FontFamily("Calibri"), "We hereby certify that all products listed above have been produced, assembled, inspected, and tested in full accordance with all specifications, drawings, and quality requirements.");
            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));

            WriteWhere += AnchoDeLinea * 3;//Salto de linea al editor
            editor.Position.Translate(MargenIzquierdo, WriteWhere);//Traslada el editor al nuevo punto de escritura

            block = new Block();
            block.TextProperties.FontSize = 13;
            block.InsertText(new FontFamily("Calibri"), "Certificamos por este medio todos los productos arriba mencionados se han producido, ensamblado, examinados, y probados de acuerdo a todas las especificaciones, dibujos, y requisitos de calidad.");
            editor.DrawBlock(block, new Size(maxWidth, double.PositiveInfinity));
        }
    }
}