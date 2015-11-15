
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mono.Data.Sqlite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ProgrammaticallyInterface
{
	[Activity (Label = "BookshelfActivity")]			
	public class BookshelfActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			new DatabaseCopy (this); // Копирование файла БД из папки Assets во внутреннюю память устройства

			base.OnCreate (bundle);
			SetContentView (Resource.Layout.BookshelfLayout);

			string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath
				(System.Environment.SpecialFolder.Personal),"library.sqlite"
			); // Конечный путь к файлу БД на внутренней памяти телефона

			SqliteConnection connection = new SqliteConnection ("Data source=" + dbPath); // Создание подключения к БД
			SqliteCommand command = connection.CreateCommand (); // Создание запроса к БД
			SqliteDataReader reader; // Объявление переменной чтения из входящего потока данных из БД

			List<string> book_name = new List<string> (); // Объявление переменной со списком книг

			connection.Open (); // Открытие подключения к БД
			command.CommandText = "SELECT name FROM book"; // Создание текста запроса к БД
			reader = command.ExecuteReader (); // Получение потока данных из БД
			while (reader.Read ()) { // Пока есть считываемые массивы данных
				book_name.Add (reader [0].ToString ()); // Сохраняем в списке книг их названия
			}
			reader.Close (); // Закрываем поток чтения из БД
			connection.Close (); // Закрываем подключение к БД

			LinearLayout mainLayout = 
				FindViewById<LinearLayout> 
				(Resource.Id.linearLayout2); // Получение доступа к основному контейнеру, куда будут вставляться остальные контейнеры с книгами
			
			for (int i = 0; i < book_name.Count / 2 + book_name.Count % 2; i++) { // Цикл по рядам книг
				LinearLayout newLinearLayout = 
					new LinearLayout (this); // Создание горизонтального контейнера, куда будут вставляться книги
				newLinearLayout.Orientation = 
					Orientation.Horizontal;

				for (int j = 0; j < 2; j ++) { // Цикл по столбцам ряда
					if (i * 2 + j < book_name.Count) { // Проверка неполного ряда
						Button newButton = new Button (this); // Создание кнопки(книги)
						newButton.Text = book_name [i * 2 + j]; // Присваивание ей текста


						if ((i * 2 + j+1)%3 == 0)
							newButton.SetBackgroundResource (Resource.Drawable.book1); // Объявление заднего фона для кнопки
						else if ((i*2 + j +1)%2 ==0)
							newButton.SetBackgroundResource (Resource.Drawable.book2); // Объявление заднего фона для кнопки
						else
							newButton.SetBackgroundResource (Resource.Drawable.book3); // Объявление заднего фона для кнопки

						LinearLayout.LayoutParams buttonParameters = 
							new LinearLayout.LayoutParams (100, 100); // Задание параметров положения для кнопки
						buttonParameters.SetMargins
						(0, 0, 5, 5); // Задание отступов

						newButton.LayoutParameters = buttonParameters; 

						newButton.Click += (object sender, EventArgs e) => 
						{
							// Обработка нажатия на кнопку
						};

						newLinearLayout.AddView (newButton); // Добавление на созданный контейнер созданной кнопки
					}
				}

				mainLayout.AddView (newLinearLayout); // Добавление на основной контейнер созданный контейнер
			}

			// Create your application here
		}
	}
}

