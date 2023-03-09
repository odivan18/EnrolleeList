using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;




namespace WindowsFormsApplication1
{

    public struct student 
{
        public string apregnum;
        public string fio;
        public string specgroup;
        public bool original;
        public string apfinalspec;
        public string math;
        public string phys;
        public string inf;
        public string rus;
        public string summ;
        public string dop;
        public string total_summ;
        public string typeentry;
        public string priv;

    public void create(string line)
    {
        int i = 0;
        apregnum = "";
        fio = "";
        specgroup = "";
        original = false;
        apfinalspec = "";
        math = "";
        phys = "";
        inf = "";
        rus = "";
        summ = "";
        dop = "";
        total_summ = "";
        typeentry = "";
        priv = "";
        for (; line[i] != ';'; i++)
            apregnum += line[i];
        for (i++; line[i] != ';'; i++)
            fio += line[i];
        for (i++; line[i] != ';'; i++)
            specgroup += line[i];
        for (i++; line[i] != ';'; i++)
            if (line[i] == '1')
                original = true;
        for (i++; line[i] != ';'; i++)
            apfinalspec += line[i];
        for (i++; line[i] != ';'; i++)
            math += line[i];
        for (i++; line[i] != ';'; i++)
            phys += line[i];
        for (i++; line[i] != ';'; i++)
            inf += line[i];
        for (i++; line[i] != ';'; i++)
            rus += line[i];
        for (i++; line[i] != ';'; i++)
            summ += line[i];
        for (i++; line[i] != ';'; i++)
            dop += line[i];
        for (i++; line[i] != ';'; i++)
            total_summ += line[i];
        for (i++; line[i] != ';'; i++)
            typeentry += line[i];
        for (i++; i < line.Length; i++)
            priv += line[i];
    }
};

    public partial class Form1 : Form
    {
        public DateTime time = DateTime.Now; //таймер для нормальной работы выпадающих списков
        public string name, buf; //строковые переменные, чтобы не жрать память другими далее
        student []ku4a; //основной массив записей, где постоянно хранится список поступающих из последнего открытого файла
        student []gruppa; //вспомогательный массив записей для работы с записями, удовлетворяющими некоторым условиям
        public int size, size2; //размеры основного и вспомогательного массива

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "Text files(*.csv) |*.csv|All files(*.*)|*.*";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //выбор файла через диалоговое окно
                openFileDialog1.ShowDialog();
                name = openFileDialog1.FileName;
                //выявление количества записей в файле
                size = System.IO.File.ReadAllLines(name).Length - 1;
                //выделение память под основной массив записей
                ku4a = new student[size];
                //открытие потока для чтения файла
                System.IO.StreamReader file = new System.IO.StreamReader(name);
                //пропуск первой строки со спецификациями
                file.ReadLine();
                //построчное чтение файла и запись каждой строки в память
                for (int i = 0; (buf = file.ReadLine()) != null; )
                    ku4a[i++].create(buf);
                //закрытие файла
                file.Close();

                //сортровка полученных данных сначала по баллам по математике, а потом по итоговому баллу
                sortMS(ku4a, size);
                //заполнение выпадающих списков
                groupListFill(ku4a, size, groupList);
                finalListFill(ku4a, size, finalList);
                //вывод данных в таблицу
                vivoz(ku4a, size);               
            }
            catch
            {
                MessageBox.Show("Не удалось открыть файл");            
            }
        }
      
        public void vivoz(student []student, int size)
        {
            //легкое оформление таблицы перед новым выводом в нее
            prepareTablet(size);
            //построчный вывод каждой записи из переданного массива в таблицу
            for (int i = 0; i < size; i++)
            {
                string or = "";
                if (student[i].original)
                    or = "ДА";
                tablet.Rows.Add(student[i].apregnum, student[i].fio, student[i].specgroup, or, student[i].apfinalspec, student[i].math, student[i].phys, student[i].inf, student[i].rus, student[i].summ, student[i].dop, student[i].total_summ, student[i].typeentry, student[i].priv);
            }
            if ((string)finalList.SelectedItem != null && (string)groupList.SelectedItem != null)
                colorize();
        }

        public student[] swap(int a, int b, student[] A)
        {
            student buff = A[a];
            A[a]=A[b];
            A[b]=buff;
            return A;
        }

        public void groupListFill(student[] tolpa, int size, ComboBox cb)
        {
            cb.SelectedIndex = 0;
            //очистка списка специальностей, накоторые были поданы документы
            cb.Items.Clear();
            cb.Items.Add("");
            //заполнение списка специальностей, на которые были поданы документы, из переданного в функцию массива записей
            for (int i = 0; i < size; i++)
                if(isNotInList(tolpa[i].specgroup, cb))
                    cb.Items.Add(tolpa[i].specgroup);
        }

        public void finalListFill(student[] tolpa, int size, ComboBox cb)
        {
            cb.SelectedIndex = 0;
            //очистка списка специальностей, накоторые были поданы документы с финальным заявлением
            cb.Items.Clear();
            //заполнение списка специальностей, на которые были поданы документы с финальным заявлением, из переданного в функцию массива записей
            for (int i = 0; i < size; i++)
                if (isNotInList(tolpa[i].apfinalspec, cb))
                    cb.Items.Add(tolpa[i].apfinalspec);
        }

        private void groupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //проверка на непрограммный выбор элемента из списка
            if (time.Subtract(DateTime.Now) < (DateTime.Now.Subtract(DateTime.Now.AddMilliseconds(500))))
            {
                //установление времени последнего выбора элемента из списка
                time = DateTime.Now;
                //сброс выбора на соседнем списке
                finalList.SelectedIndex = 0;
                visibility();
                //если был выбран пустой вариант, вугружаем основной массив и выходим из функции
                if ((string)groupList.SelectedItem == "")
                {
                    vivoz(ku4a, size);
                    return;
                }
                //иначе
                //начало формирование вспомогательного массива записей, удовлетворяющего выбранному условию
                size2 = 0;
                //выявление размера вспомогательного массива
                for (int i = 0; i < size; i++)
                    if (ku4a[i].specgroup == (string)groupList.SelectedItem)
                        size2++;
                //выделение памяти под вспомогательный массив
                gruppa = new student[size2];
                //формирование вспомогательного массива
                int ind = 0;
                for (int i = 0; i < size; i++)
                    if (ku4a[i].specgroup == (string)groupList.SelectedItem)
                    {
                        gruppa[ind] = ku4a[i];
                        ind++;
                    }
                //сортировка вспомогательного массива в зависимости от того, информатика или физика выжна
                if (IsInfMain((string)groupList.SelectedItem))
                    sortIMS(gruppa, size2);
                else
                    sortPMS(gruppa, size2);
                //заполнение таблицы вспомогательным массивом
                vivoz(gruppa, size2);
            }
        }

        private void finalList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (time.Subtract(DateTime.Now) < (DateTime.Now.Subtract(DateTime.Now.AddMilliseconds(500))))
            {
                time = DateTime.Now;
                groupList.SelectedIndex = 0;
                visibility();
                if ((string)finalList.SelectedItem == "")
                {
                    vivoz(ku4a, size);
                    return;
                }
                size2 = 0;
                for (int i = 0; i < size; i++)
                    if (ku4a[i].apfinalspec == (string)finalList.SelectedItem && ku4a[i].apfinalspec == ku4a[i].specgroup)
                        size2++;
                gruppa = new student[size2];
                for (int i = 0, j = 0; i < size; i++)
                    if (ku4a[i].apfinalspec == (string)finalList.SelectedItem&&ku4a[i].apfinalspec==ku4a[i].specgroup)
                    {
                        gruppa[j] = ku4a[i];
                        j++;
                    }
                kostyl();
                if (IsInfMain((string)finalList.SelectedItem))
                    sortIMS(gruppa, size2);
                else
                    sortPMS(gruppa, size2);
                vivoz(gruppa, size2);                
            }            
        }

        public bool isNotInList(string line, ComboBox cb)
            //проверка, находится ли строка line в списке cb
        {
            for (int i = 0; i < cb.Items.Count; i++)
                if (line == (string)cb.Items[i])
                    return false;
            return true;
        }

        public void kostyl()
            //костыль для удаления повторяющихся имен из списка финальных заявлений
        {
            for (int i = 1; i < size2; i++)
            {
                bool check = false;
                buf = gruppa[i].apregnum;
                for (int j = i - 1; j >= 0 && !check; j--)
                    if (buf == gruppa[j].apregnum)
                        check = true;
                if (check)
                {
                    for (int j = i; j < size2 - 1; j++)
                        gruppa[j] = gruppa[j + 1];
                    size2--;
                    i--;
                }
            }
        }

        private void tablet_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
            //нумерация строк в головной ячейке
        {
            e.Row.HeaderCell.Value = Convert.ToString(e.Row.Index + 1);
        }

        private void butt_Click(object sender, EventArgs e)
            //подстановка нового имени с итоговыми баллами в таблицу
        {
            //очистка строчных буферов, выделение вспомогательной целочисленной переменной
            int i = 0;
            name = "";
            buf = "";
            //попытки прочитать комбинации имя-баллы или баллы-имя
            try
            {                
                //принятие всех символов до первого пробела за имя
                for (; tb.Text[i] != ' '; i++)
                    name += tb.Text[i];
                //пропуск пробелов
                while (tb.Text[i++] == ' ') ;
                i--;
                //принятие всех символов на конце за количество баллов
                for (; i < tb.Text.Length; i++)
                    buf += tb.Text[i];
                //проверка, являются ли записанные символы числом
                buf = Convert.ToString(Convert.ToInt32(buf));                               
            }
            catch
            {
                try
                {
                    //очистка строчных буферов, выделение вспомогательной целочисленной переменной
                    name = "";
                    buf = "";
                    i = 0;
                    //принятие всех начальных символов до первого пробела за число
                    for (; tb.Text[i] != ' '; i++)
                        buf += tb.Text[i];
                    //проверка, являются ли записанные символы числом
                    buf = Convert.ToString(Convert.ToInt32(buf));
                    //пропуск пробелов
                    while (tb.Text[i++] == ' ') ;
                    //принятие всех символов после первых пробелов до конца строки за имя
                    for (; i < tb.Text.Length; i++)
                        name += tb.Text[i];
                }
                catch
                //в случае неудасчного прочтения выводится сообщение об ошибке и функция прекращает свою работу
                {
                    MessageBox.Show("Не удалось прочитать данные");
                    return;
                }
            }
            //составление строки, подходящей конструктору
            buf = " ; " + name + " ; ; ; ; ; ; ; ; ; ; " + buf + " ; ; ";
            //обозначаем, что вспомогательный массив увеличился на одну запись
            size2++;
            //создаем временный массив записей
            student[] A = new student[size2];
            //копируем во временный массив вспомогательный
            for (i = 0; i < size2 - 1; i++)
                A[i] = gruppa[i];
            //создаем запись пользователя
            student pupa = A[0];
            pupa.create(buf);
            //записываем ее в конец временного массива
            A[size2 - 1] = pupa;
            //сортируем временный массив по итоговому баллу
            SortTSum(A, size2);
            //поиск пользовательской записи в отсортированном массиве
            int gdePupa = 0;
            for (; A[gdePupa].fio != pupa.fio; gdePupa++) ;
            //переписываем временный массив во вспомогательный
            gruppa = A;       
            //выводим в таблицу отсортированный массив с пользовательской записью
            vivoz(gruppa, size2);
            //красим строку с пользовательской записью в приятный бтрюзовый цвет
            tablet.Rows[gdePupa].DefaultCellStyle.BackColor = Color.CadetBlue;
            tablet.CurrentCell = tablet.Rows[gdePupa].Cells[1];
        }

        public void SortTSum(student[] A, int N)
        {
            //переменная конца неотсортированной чатси массива
            int fin = N - 1;
            //для переменной от нуля до конца неотсортированной части
            for (int i = 0; i < fin; i++)
            {
                //если не указан итоговый балл, сброс в конец
                if (A[i].total_summ == "")
                {
                    A = swap(i, fin, A);
                    i--;
                    fin--;
                }
                //иначе
                else
                {
                    //принимаем текущий элемент за максимум
                    int ind = i;
                    //для всех неотсортированных элементов
                    for (int j = i + 1; j < fin + 1; j++)
                        //если указан итоговый балл студента j и он больше, чем у студента i
                        if (A[j].total_summ != "" && Convert.ToInt32(A[j].total_summ) > Convert.ToInt32(A[ind].total_summ))
                            //запоминаем индес j
                            ind = j;
                    //если в массиве нашелся больший элемент, то ставим его на место i
                    if (ind != i)
                        A = swap(i, ind, A);
                }
            }
        }
        
        public void sortIMS(student[] A, int size)
        {
            //объявляем локальные переменные
            int fin = size - 1; //конец неотсортированной части
            int i = 0; //номер элемента, стоящие перед которым уже отсортированы
            int ind = 0; //номер студента в неотсортированном списке с лучшими баллами
            int j = 0; //номер записи из неотсортированной чати списка, которую проверяем на лучший балл
            //цикл для отброса в конец списка записей без итогового балла и баллов по информатике и математике
            for (; i < fin; i++)
                if (A[i].total_summ == "" || A[i].inf == "" || A[i].math == "")
                {
                    A = swap(i, fin, A);
                    i--;
                    fin--;
                }
            //для всех неотсортированных элементов
            for (i = 0; i <= fin; i++)
            {
                //принимаем текущий элемент за максимум
                ind = i;
                //для все последующих элементов происходит сортировка сначала по итоговому баллу
                //потом, если итоговые баллы равны, происходит сравнение по баллам по математике
                //если же и они равны, то происходит сравнение по балалам по информатике
                //в случае, когда равны все три значения, происходит сортировка в алфавитном порядке
                for (j = i + 1; j < fin; j++)
                    if (Convert.ToInt32(A[ind].total_summ) < Convert.ToInt32(A[j].total_summ))
                        ind = j;
                    else
                        if (Convert.ToInt32(A[ind].total_summ) == Convert.ToInt32(A[j].total_summ))
                        if (Convert.ToInt32(A[ind].math) < Convert.ToInt32(A[j].math))
                            ind = j;
                        else
                            if (Convert.ToInt32(A[ind].math) == Convert.ToInt32(A[j].math))
                            if (Convert.ToInt32(A[ind].inf) < Convert.ToInt32(A[j].inf))
                                ind = j;
                            else
                                if (Convert.ToInt32(A[ind].inf) == Convert.ToInt32(A[j].inf) && string.Compare(A[ind].fio, A[j].fio) > 0)
                                ind = j;
                if (ind != i)
                    A = swap(i, ind, A);
            }
        }

        public void sortPMS(student[] A, int size)
        {
            int fin = size - 1; //переменная конца сортируемой части
            int i = 0; //переменная номера текущего элемента
            int ind = 0; //индекс элемента, который будет отсортирован
            int j = 0; //вспомогательная переменная внутреннего цикла
            //цикл для отброса в конец списка записей без информации об итоговом балее или баллах по математике или физике
            for (; i < fin; i++)
                if (A[i].total_summ == "" || A[i].phys == "" || A[i].math == "")
                {
                    A = swap(i, fin, A);
                    i--;
                    fin--;
                }
            //для всех неотсортированных элементов
            for (i = 0; i <= fin; i++)
            {
                //принимаем текущую запись за запись с лучшими баллами
                ind = i;
                //цикл для всех последующих записей
                for (j = i + 1; j < fin; j++)
                    //сортировка по итоговому баллу
                    //если они равны, то происходит сравнение по баллу по математике
                    if (Convert.ToInt32(A[ind].total_summ) < Convert.ToInt32(A[j].total_summ))
                        ind = j;
                    else
                        if (Convert.ToInt32(A[ind].total_summ) == Convert.ToInt32(A[j].total_summ))
                        if (Convert.ToInt32(A[ind].math) < Convert.ToInt32(A[j].math))
                            ind = j;
                        else
                            if (Convert.ToInt32(A[ind].math) == Convert.ToInt32(A[j].math))
                            if (Convert.ToInt32(A[ind].phys) < Convert.ToInt32(A[j].phys))
                                ind = j;
                            else
                                if (Convert.ToInt32(A[ind].phys) == Convert.ToInt32(A[j].phys) && string.Compare(A[ind].fio, A[j].fio) > 0)
                                ind = j;
                if (ind != i)
                    A = swap(i, ind, A);
            }
        }

        public void sortMS(student[] A, int size)
        {
            int fin = size - 1; //переменная конца сортируемой части
            int i = 0; //переменная номера текущего элемента
            int ind = 0; //индекс элемента, который будет отсортирован
            int j = 0; //вспомогательная переменная внутреннего цикла
            //цикл для отброса в конец списка записей без итогового балла и балла по математике
            for (;i<fin;i++)
                if (A[i].total_summ == "" || A[i].math == "")
                {
                    A = swap(i, fin, A);
                    i--;
                    fin--;
                }
            //для всех неотсортированных элементов
            for (i=0; i <= fin; i++)
            {
                //принимаем текущую запись за запись с лучшими баллами
                ind = i;
                //сортировка по итоговому баллу
                //если они равны, то проверяются баллы пом математике
                //если равны и они, то сортировка происходит по алфавиту
                for (j = i + 1; j < fin; j++)
                    if (Convert.ToInt32(A[ind].total_summ) < Convert.ToInt32(A[j].total_summ))
                        ind = j;
                    else
                        if (Convert.ToInt32(A[ind].total_summ) == Convert.ToInt32(A[j].total_summ))
                        if (Convert.ToInt32(A[ind].math) < Convert.ToInt32(A[j].math))
                            ind = j;
                        else
                            if (Convert.ToInt32(A[ind].math) == Convert.ToInt32(A[j].math))
                            if (string.Compare(A[ind].fio, A[j].fio) > 0)
                                ind = j;
                if (ind != i)
                    A = swap(i, ind, A);
            }
        }

        public bool IsInfMain(string spec)
        {
            //проверка, совпадает ли переданная в фунцию строка с одной из заранее записанных
            if (spec == "ИТД.Б" || spec == "СОИ.Б" || spec == "ЭВМ.Б")
                return true;
            else return false;
        }

        public void colorize()
        {
            //если отображается выборка по заявлению на кифедру или финальному заявлению
            if ((string)groupList.SelectedItem != "" || (string)finalList.SelectedItem != "")
            {
                //переменная для работы с названием кафедры
                string group;
                //определение по какой кафедре идет отображение данных
                if ((string)groupList.SelectedItem != "")
                    group = (string)groupList.SelectedItem;
                else
                    group = (string)finalList.SelectedItem;
                int n = tablet.RowCount - 1; //число строк, которые нужно покрасить
                int kvot = kvota(group); //количесво бюджетных мест в зависимости от группы
                int pos = 0; //переменная для определения потенциального места в списке записей с финальным заявлением
                //для всех строк
                for(int i=0;i<n;i++)
                    //если кафедра заявления совпадает с кафедрой финального заявления и на ней хватает бюджетных мест
                    if((string)tablet.Rows[i].Cells[2].Value== (string)tablet.Rows[i].Cells[4].Value&&pos<kvot)
                    {
                        //окрашшиваем строку в зеленый и предварительно занимаем бюджетное место
                        tablet.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                        pos++;
                    }
                    else
                    //иначе если не подано финальное заявление
                        if((string)tablet.Rows[i].Cells[4].Value==""&&pos<kvot)
                        //окрашиваем строку в оранжевый цвет
                            tablet.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                        else
                        //иначе, если бюджетных мест не осталось, красим строку в красный
                            if(pos>=kvot)
                                tablet.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
            }
        }

        public int kvota(string group)
        {
            return 10;
        }

        public void prepareTablet(int size)
        {
            //принимает число записей для следующей записи в таблицу
            //задаем ширину столца с номерами строки 
            tablet.RowHeadersWidth = 40;
            //очищаем таблицу
            tablet.Rows.Clear();
            //за каждый символ в числе записей расширяем головной столбец
            for (int n = 10; n <= size; n *= 10)
                tablet.RowHeadersWidth += 6;
        }

        private void FindBut_Click(object sender, EventArgs e)
        {
            //для всех отображенных записей
            for(int i =0;i<size2;i++)
            {
                //если имя полностью содержит текст из строки поиска
                if(iscontain((string)tablet.Rows[i].Cells[1].Value,NameBox.Text))
                {
                    //программный выбор строки и завершение функции
                    tablet.CurrentCell = tablet.Rows[i].Cells[1];
                    return;
                }
            }
            //если полных совпадений не нашлось, выводится окно ошибки поиска
            MessageBox.Show("Студент не найден");
        }

        public void selectRow(string name)
        {
            int i = 0;
            for(;i<size2;i++)
                if((string)tablet.Rows[i].Cells[1].Value == name)
                {
                    tablet.CurrentCell = tablet.Rows[i].Cells[1];
                    return;
                }
        }

        public void visibility()
        {
            if ((string)groupList.SelectedItem != null || (string)finalList.SelectedItem != null)
            {
                if ((string)groupList.SelectedItem != "" || (string)finalList.SelectedItem != "")
                {
                    butt.Visible = true;
                    tb.Visible = true;
                    NameBox.Visible = true;
                    findBut.Visible = true;
                }
                else
                {
                    butt.Visible = false;
                    tb.Visible = false;
                    NameBox.Visible = false;
                    findBut.Visible = false;
                }
            }
        }

        public bool sepor(char symbol)
        {
            //строка с возможными разделителями слов
            string seporetors = " .,:;";
            //если символ один из разделителей, возвращается истина
            for (int i = 0; i < seporetors.Length; i++)
                if (symbol == seporetors[i])
                    return true;
            //иначе ложь
            return false;
        }

        public bool iscontain(string main, string checker)
        {
            //принимает главнуюю строку, в которой будет искаться вспомогательная
            //для всех символов главноу строки, пока за ним может поместиться вспомогательная
            for(int i=0;i<main.Length-checker.Length;i++)
            {
                //запоминаем позицию текущего символа
                int j = i;
                //подсчет сколько символов подряд из вспомогательной строки встречаются в основной
                for (; j < main.Length && j - i < checker.Length && main[j] == checker[j - i]; j++) ;
                //если вся вспомогательная строка нашлась в основной, возвращаем истину
                if (j - i == checker.Length)
                    return true;
            }
            return false;
        }
    }
}