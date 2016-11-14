using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
namespace BudgetProgram
{

    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            //1 = String
            //2 = Float
            //3 = Date
            int sortType;
            if (ColumnToSort == 0 || ColumnToSort == 3 || ColumnToSort == 4)
                sortType = 1;
            else if (ColumnToSort == 2)
                sortType = 2;
            else if (ColumnToSort == 1)
                sortType = 3;
            else
                throw new Exception("New column needs to have a type specified in the ListViewColumnSorter.cs class");

            

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            if (sortType == 1)
            // Compare the two items as strings
            {

                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }

            else if (sortType == 2)
            // Compare the two items as Floats
            {
                float x_par = float.Parse(listviewX.SubItems[ColumnToSort].Text.Split(' ').First());
                float y_par = float.Parse(listviewY.SubItems[ColumnToSort].Text.Split(' ').First());
                compareResult = ObjectCompare.Compare(x_par, y_par);

            }

            else if (sortType == 3)
            {
                DateTime x_par = DateTime.Parse(listviewX.SubItems[ColumnToSort].Text.Split(' ').First());
                DateTime y_par = DateTime.Parse(listviewY.SubItems[ColumnToSort].Text.Split(' ').First());
                compareResult = ObjectCompare.Compare(x_par, y_par);
            }

            else
                throw new Exception("daum son");
            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }

}

