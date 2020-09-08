using EsameCSharp.Movies;
using Esercizio1.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esercizio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //accedo all'assembly del cliente e recupero la lista di stringhe che rappresenta il CSV
            var moviesCsv = MovieManager.GetMovies();

            //Creo una classe che rappresenta un film, quindi ha le stesse property che troverò nel CSV
            //Istanzio una lista di Movie che popolerò con i dati del CSV e che mi servirà
            //Come sorgente dati per la mia datagridview
            var movies = new List<Movie>();
            
            //Esempio di riga del CSV
            //tarantino;le iene;1996;thriller;13.45
            
            //Itero le righe del mio CSV per popolare la lista movies
            foreach (var item in moviesCsv)
            {
                //ogni riga è in formato CSV quindi devo dividerla in sottostringhe 
                //usando il carattere di delimitazione fornito
                var splittedItem = item.Split(';');
                //aggiungo alla mia lista un nuovo oggetto popolando correttamente le sue property
                var movie = new Movie();
                movie.Regista = splittedItem[0];
                movie.Titolo = splittedItem[1];
                movie.Anno = int.Parse(splittedItem[2]);
                movie.Genere = splittedItem[3];
                movie.Prezzo = double.Parse(splittedItem[4]);
                movies.Add(movie);
            }
            //Associo la mia lista di oggetti di tipo Movie alla datagridView come sorgente dati
            dataGridView1.DataSource = movies;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //recupero dalla datagridview la sorgente dati facendo un cast
            var movies = dataGridView1.DataSource as List<Movie>;
            //apro il dialog per permettere all'utente di scegliere il nome del file in cui salvare il CSV
            var result = saveFileDialog1.ShowDialog();
            //verifico che il risultato del dialog sia OK, altrimenti non devo fare nulla
            if(result == DialogResult.OK)
            {
                //apro uno streamWriter utilizzando il file scelto dall'utente per salvare i dati
                using (var strWriter = new StreamWriter(saveFileDialog1.FileName))
                {
                    //per ogni elemento della lista scrivo una riga nel CSV utilizzando il metodo GetCSVformat
                    foreach (var movie in movies)
                    {
                        strWriter.WriteLine(movie.GetCSVformat());
                    }
                }
            }
        }
    }
}
