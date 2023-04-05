using System;
using System.Collections.Generic;

using BudgetWatcher.Database.Schemas;

using Word = Microsoft.Office.Interop.Word;

namespace BudgetWatcher.Builders
{
    public class WordBuilder
    {
        readonly Word.Application m_WordApp = null;
        readonly Word.Document m_Document = null;

        public Action OnDocumentSave;
        public Action OnDocumentSaved;

        public WordBuilder()
        {
            // open
            m_WordApp = new Word.Application();
            m_Document = m_WordApp.Documents.Add();

            // setup page
            Word.PageSetup pageSetup = m_Document.PageSetup;
            pageSetup.PaperSize = Word.WdPaperSize.wdPaperA4;

            // setup table styles
            Word.Style tableStyle = m_Document.Styles.Add("Expense History Table Style", Word.WdStyleType.wdStyleTypeTable);
            tableStyle.Table.Borders.Enable = 1;
        }

        public WordBuilder AddEmptyLines(int count, float fontSize = 11)
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            range.Font.Size = fontSize;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            for (int i = 0; i < count; i++)
            {
                range.InsertParagraphAfter();
                range.Font.Size = fontSize;
                range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            }

            return this;
        }

        public WordBuilder AddTableOfContents()
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            Word.TableOfContents tableOfContents = m_Document.TablesOfContents.Add(Range: range, UseHyperlinks: true);
            tableOfContents.Range.InsertBefore("Cuprins\n");

            range.InsertParagraphAfter();

            return this;
        }

        public WordBuilder UpdateTableOfContents()
        {
            Word.TableOfContents tableOfContents = m_Document.TablesOfContents[1];
            tableOfContents.Update();


            return this;
        }

        public WordBuilder AddTitle(string title)
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            paragraph.set_Style("Title");

            range.Text = title;
            range.Font.Size = 28;
            range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            range.InsertParagraphAfter();

            return this;
        }

        public WordBuilder AddSubtitle(string subtitle)
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            paragraph.set_Style("Subtitle");

            range.Text = subtitle;
            range.Font.Size = 11;
            range.Font.Italic = 1;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            range.InsertParagraphAfter();

            return this;
        }

        public WordBuilder AddHeading1(string heading1)
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            paragraph.set_Style("Heading 1");

            range.Text = heading1;
            range.Font.Size = 16;
            range.Font.Bold = 1;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            range.InsertParagraphAfter();

            return this;
        }

        public WordBuilder AddHeading2(string heading2)
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            paragraph.set_Style("Heading 2");

            range.Text = heading2;
            range.Font.Size = 13;
            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

            range.InsertParagraphAfter();

            return this;
        }

        public WordBuilder AddTable(List<Expense> expenses)
        {
            Word.Paragraph paragraph = m_Document.Paragraphs.Last;
            Word.Range range = paragraph.Range;

            range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            Word.Table table = m_Document.Tables.Add(range, expenses.Count + 1, 6);
            table.Cell(1, 1).Range.Text = "Nr. crt";
            table.Cell(1, 2).Range.Text = "Denumire";
            table.Cell(1, 3).Range.Text = "Valoare";
            table.Cell(1, 4).Range.Text = "Categorie";
            table.Cell(1, 5).Range.Text = "Frecvență";
            table.Cell(1, 6).Range.Text = "Descriere";

            int line = 2;
            foreach (var expense in expenses)
            {
                table.Cell(line, 1).Range.Text = (line - 1).ToString();
                table.Cell(line, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

                table.Cell(line, 2).Range.Text = expense.Name;

                table.Cell(line, 3).Range.Text = expense.Value.ToString() + " RON";
                table.Cell(line, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;

                table.Cell(line, 4).Range.Text = expense.Category.Name;
                table.Cell(line, 5).Range.Text = expense.Frequency.Name;
                table.Cell(line, 6).Range.Text = expense.Details;

                line++;
            }

            table.set_Style("Expense History Table Style");
            table.Columns.AutoFit();
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);

            Word.Row headerRow = table.Rows[1];
            headerRow.Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorPaleBlue;
            headerRow.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            headerRow.Range.Font.Bold = 1;

            range.InsertParagraphAfter();

            return this;
        }

        public WordBuilder SaveAs(string filePath)
        {
            OnDocumentSave?.Invoke();

            m_Document.SaveAs(filePath);

            OnDocumentSaved?.Invoke();

            return this;
        }

        public WordBuilder Close()
        {
            m_WordApp.Quit();

            return this;
        }
    }
}
