using System;
using System.Collections.ObjectModel;
using System.ComponentModel;



namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Class MultiPlayerDetailsViewModel.
    /// </summary>
    /// <seealso cref="MazeGUI.NotifyChanged" />
    class MultiPlayerDetailsViewModel : NotifyChanged
    {
        /// <summary>
        /// The model
        /// </summary>
        private IMultiPlayerModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerDetailsViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MultiPlayerDetailsViewModel(IMultiPlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate(Object sender, PropertyChangedEventArgs e){
                if (e.PropertyName == "Maze")
                {
                    MultiPlayer mp = new MultiPlayer(model);
                    mp.Show();
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                }
            };

        }
        /// <summary>
        /// Gets or sets the games list.
        /// </summary>
        /// <value>The games list.</value>
        public ObservableCollection<string> GamesList
        {

            get
            {
                return new ObservableCollection<string>(model.GamesList);
            }

            set
            {
                NotifyPropertyChanged("GamesList");
            }

        }

        /// <summary>
        /// Gets or sets the maze rows.
        /// </summary>
        /// <value>The maze rows.</value>
        public int MazeRows
        {
            get { return Properties.Settings.Default.MazeRows; }
            set
            {
                NotifyPropertyChanged("MazeRows");
            }
        }

        /// <summary>
        /// Gets or sets the maze cols.
        /// </summary>
        /// <value>The maze cols.</value>
        public int MazeCols
        {
            get { return Properties.Settings.Default.MazeCols; }
            set
            {
                NotifyPropertyChanged("MazeCols");
            }
        }

        /// <summary>
        /// Starts the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public void Start(string mazeName, int rows, int cols)
        {
            model.Start(mazeName, rows,  cols);
            
        }

        /// <summary>
        /// Joins the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        public void Join(string mazeName)
        {
        model.Join(mazeName);
        }
        
    }
}
