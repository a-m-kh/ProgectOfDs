using System;
using System.IO;
using System.Text;
using System.Collections.Generic; // for list
using System.Linq; // for converting array to list
using System.Diagnostics; // for timer
namespace ConsoleApp10
{

    class DS_Dis
    {

        public static int H_Dis(string Dis)
        {
            int Asci = 0;
            for (int i = 4; i < Dis.Length; i++)
            {
                Asci += (int)Dis[i];
            }
            return Asci - 970;
        }


        public Dis[] table = new Dis[260];
        public void add(Dis DD)
        {
            int index = H_Dis(DD.Name);
            if (table[index] == null)
            {
                table[index] = DD;
            }
            else
            {
                if (table[index].is_deleted)
                {
                    table[index] = DD;
                    return;
                }
                Dis Colision = table[index];

                while (!(Colision.Colision == null || Colision.Colision.is_deleted))
                {
                    Colision = Colision.Colision;
                }
                Colision.Colision = DD;
            }
        }
        public Dis Search(string Name)
        {
            Dis output;
            int index = H_Dis(Name);
            if (table[index] == null)
            {
                output = null;
                return null;
            }
            if (table[index].Name == Name)
            {
                output = table[index];
            }
            else
            {
                Dis dis = table[index];

                if (dis.Colision == null)
                {
                    output = null;
                    return null;
                }
                while (dis.Name != Name)
                {
                    if (dis.Colision == null)
                    {
                        output = null;
                        return null;
                    }
                    dis = dis.Colision;
                }
                output = dis;
            }
            if (output == null)
            {
                return null;
            }
            else
            {
                if (output.is_deleted)
                {
                    return null;
                }
                return output;
            }
        }
        public bool remove(string Name)
        {
            int index = H_Dis(Name);
            if (table[index] == null)
            {
                return false;
            }
            else
            {
                Dis dis = table[index];
                while (dis.Name != Name)
                {
                    dis = dis.Colision;
                    if (dis == null) { break; }
                }
                if (dis == null)
                {
                    return false;
                }
                else
                {
                    dis.is_deleted = true;
                    return true;
                }
            }
        }
        public Dis[] get_random_diseases(int count)
        {
            Dis[] random_diseases = new Dis[count];
            int counter = 0;
            foreach (Dis rand in this.table)
            {
                if (rand != null)
                {
                    random_diseases[counter] = rand;
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }
            return random_diseases;
        }
    }
    class DS_Drug
    {


        public static int H_Drug(string Drug)
        {
            int Asci = 0;
            for (int i = 5; i < Drug.Length; i++)
            {
                Asci += (int)Drug[i];
            }
            return Asci - 970;
        }


        public Drug[] table = new Drug[260];
        public void add(Drug DD)
        {
            int index = H_Drug(DD.Name);
            if (table[index] == null)
            {
                table[index] = DD;
            }
            else
            {
                if (table[index].is_deleted)
                {
                    table[index] = DD;
                    return;
                }
                Drug Colision = table[index];

                while (!(Colision.Colision == null || Colision.Colision.is_deleted))
                {
                    Colision = Colision.Colision;
                }
                Colision.Colision = DD;
            }
        }
        public Drug Search(string Name)
        {
            Drug output;
            int index = H_Drug(Name);
            if (table[index] == null)
            {
                output = null;
                return null;
            }
            if (table[index].Name == Name)
            {
                output = table[index];
            }
            else
            {
                Drug drug = table[index];

                if (drug.Colision == null)
                {
                    output = null;
                    return null;
                }
                while (drug.Name != Name)
                {
                    if (drug.Colision == null)
                    {
                        output = null;
                        return null;
                    }
                    drug = drug.Colision;
                }
                output = drug;
            }
            if (output == null)
            {
                return null;
            }
            else
            {
                if (output.is_deleted)
                {
                    return null;
                }
                return output;
            }
        }
        public bool remove(string Name)
        {
            int index = H_Drug(Name);
            if (table[index] == null)
            {
                return false;
            }
            else
            {
                Drug drug = table[index];
                while (drug.Name != Name)
                {
                    drug = drug.Colision;
                    if (drug == null) { break; }
                }
                if (drug == null)
                {
                    return false;
                }
                else
                {
                    drug.is_deleted = true;
                    return true;
                }
            }
        }
        public Drug[] get_random_drug(int count)
        {
            Drug[] random_drugs = new Drug[count];
            int counter = 0;
            foreach (Drug rand in this.table)
            {
                if (rand != null)
                {
                    random_drugs[counter] = rand;
                    counter++;
                }
                if (counter == count)
                {
                    break;
                }
            }
            return random_drugs;
        }
    }


    class alergi
    {
        public Drug drug;
        public bool status;
        public alergi(Drug Dr, bool sta)
        {
            drug = Dr;
            status = sta;
        }

    }
    class effect
    {
        public Drug drug;
        public string effects;
        public effect(Drug Dr, string eff)
        {
            drug = Dr;
            effects = eff;
        }
    }

    class Drug
    {
        public string Name;
        public int Price;
        public List<effect> effects = null;
        public Drug Colision = null;
        public bool is_deleted = false;
        public Drug(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public void AddEfect(Drug drug, string ef)
        {
            effect jadid = new effect(drug, ef);
            if (effects == null)
            {
                effects = new List<effect>();
            }
            effects.Add(jadid);
        }
    }


    class Dis
    {
        public string Name;
        public List<alergi> Alergies;
        public Dis Colision = null;
        public bool is_deleted = false;
        public Dis(string name)
        {
            Name = name;
        }
        public void add_alergies(alergi al)
        {
            if (Alergies == null)
            {
                Alergies = new List<alergi>();
            }
            this.Alergies.Add(al);
        }
    }
    class Program
    {

        static bool is_disease_input_correct(string disease_name)
        {
            for (int i = 4; i < disease_name.Length; i++)
            {
                if ((int)disease_name[i] < 97 || (int)disease_name[i] > 122)
                {
                    return false;
                }
            }
            if (disease_name.Length != 14)
            {
                return false;
            }
            if (disease_name.Substring(0, 3) != "Dis")
            {
                return false;
            }
            return true;
        }
        static bool is_drug_input_correct(string disease_name)
        {
            for (int i = 5; i < disease_name.Length; i++)
            {
                if ((int)disease_name[i] < 97 || (int)disease_name[i] > 122)
                {
                    return false;
                }
            }
            if (disease_name.Length != 15)
            {
                return false;
            }
            if (disease_name.Substring(0, 4) != "Drug")
            {
                return false;
            }
            return true;
        }
        static bool random_boolean()
        {
            var random = new Random();
            bool random_bool = false;
            if (random.Next(2) == 0)
            {
                random_bool = true;
            }
            return random_bool;
        }
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            List<string> warnings = new List<string>();
            DS_Dis dises = new DS_Dis();
            DS_Drug drugs = new DS_Drug();
            Console.WriteLine("Pharmacy Application");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter the disered request by entering the option code:");
            Console.WriteLine("1. Start Reading File");
            Console.WriteLine("2. Check for drug interactions");
            Console.WriteLine("3. Examintaion of drug sensitivity in a prescription");
            Console.WriteLine("4. Calculate the price factor of a prescription drug");
            Console.WriteLine("5. Add information");
            Console.WriteLine("6. Delete information");
            Console.WriteLine("7. Search");
            Console.WriteLine("8. Show Warnings");
            Console.WriteLine("9. Save data");
            Console.WriteLine("10 Show a disease alergies");
            bool is_files_read = false;
            string path_to_datas = null;
            while (true)
            {

            state: Console.Write("YOUR REQUEST : ");

                int request = int.Parse(Console.ReadLine());
                if (request != 1)
                {
                    if (is_files_read == false)
                    {
                        Console.WriteLine("can't do any operation before reading files !");
                        warnings.Add("trying to do an operation before reading files !");
                        continue;
                    }
                }
                if (request == 1)
                {
                    if (is_files_read)
                    {
                        warnings.Add("trying to read files two times !");
                        Console.WriteLine("trying to read files two times !");
                        continue;
                    }
                    Console.Write("Enter path to data :");
                    path_to_datas = Console.ReadLine();
                    watch.Start();
                    is_files_read = true;
                    Console.WriteLine("Reading files ... ");
                    string[] lines_drug = File.ReadAllLines(@$"{path_to_datas}\drugs.txt", Encoding.UTF8);
                    for (int i = 0; i < lines_drug.Length; i++)
                    {
                        string[] x = lines_drug[i].Split(" : ");
                        Drug drug = new Drug(x[0], int.Parse(x[1]));
                        drugs.add(drug);
                    }
                    string[] lines_dis = File.ReadAllLines(@$"{path_to_datas}\diseases.txt", Encoding.UTF8);
                    for (int i = 0; i < lines_dis.Length; i++)
                    {
                        Dis dis = new Dis(lines_dis[i]);
                        dises.add(dis);
                    }
                    string[] lines_efect = File.ReadAllLines(@$"{path_to_datas}\effects.txt");
                    for (int i = 0; i < lines_efect.Length; i++)
                    {
                        string[] c = lines_efect[i].Split(" ; ");
                        string[] d = c[0].Split(" : ");
                        effect[] efff = new effect[c.Length];
                        string d_asli = d[0];
                        string[] f = d[1].Split('(', ')', ',');
                        string first_d = f[1];
                        Drug drr = drugs.Search(first_d);
                        string first_ef = f[2];
                        effect jadid = new effect(drr, first_ef);
                        efff[0] = jadid;
                        for (int j = 1; j < c.Length; j++)
                        {
                            string[] a = c[j].Split('(', ')', ',');
                            string dr = a[1];
                            string ef = a[2];
                            Drug drr1 = drugs.Search(dr);
                            effect jadid1 = new effect(drr1, ef);
                            efff[j] = jadid1;
                        }
                        Drug nemone = drugs.Search(d_asli);
                        nemone.effects = efff.ToList();
                    }
                    string[] lines_Alergies = File.ReadAllLines(@$"{path_to_datas}\alergies.txt");
                    for (int j = 0; j < lines_Alergies.Length; j++)
                    {
                        string[] mesal = lines_Alergies[j].Split(':', ';');
                        string[] mesla2 = new string[mesal.Length - 1];
                        string dis_a = "";
                        for (int i = 0; i < mesal[0].Length - 1; i++)
                        {
                            dis_a += mesal[0][i];
                        }
                        for (int i = 0; i < mesal.Length - 1; i++)
                        {
                            string q = mesal[i + 1];
                            string[] s = q.Split(' ', ')', '(');
                            mesla2[i] = s[2];

                        }
                        alergi[] aler = new alergi[mesal.Length - 1];
                        for (int i = 0; i < mesal.Length - 1; i++)
                        {
                            string[] finaly = mesla2[i].Split(',');
                            Drug nem = drugs.Search(finaly[0]);
                            if (finaly[1] == "+")
                            {
                                alergi n = new alergi(nem, true);
                                aler[i] = n;
                            }
                            else
                            {
                                alergi n = new alergi(nem, false);
                                aler[i] = n;
                            }
                        }
                        Dis dis2 = dises.Search(dis_a);
                        dis2.Alergies = aler.ToList();
                    }
                    Console.WriteLine("Reading is over !");
                }
                else if (request == 2)
                {
                    Console.WriteLine("Enter your drug name :");
                    string drug_name = Console.ReadLine();
                    bool is_input_ok = is_drug_input_correct(drug_name);
                    if (!is_input_ok)
                    {
                        Console.WriteLine("Wrong input!");
                        warnings.Add($"while Check for drug interactions, wrong inputs were given {drug_name}");
                        continue;
                    }
                    watch.Start();
                    Drug drug_object = drugs.Search(drug_name);
                    if (drug_object == null)
                    {
                        Console.WriteLine("drug doesn't exist!");
                        warnings.Add($"while Checking for drug interactions, input drug {drug_name} doesn't exist!");
                    }
                    else
                    {
                        Console.Write($"({drug_name}) :");
                        if (drug_object.effects == null)
                        {
                            Console.WriteLine($"drug {drug_object.Name} has no effects on other drugs !");
                            continue;
                        }
                        foreach (effect efc in drug_object.effects)
                        {
                            if (efc.drug.is_deleted)
                            {
                                continue;
                            }
                            if (efc == null) { continue; }
                            Console.Write($" ({efc.drug.Name}, {efc.effects}), ");
                        }
                        Console.WriteLine();
                    }
                }
                else if (request == 3)
                {
                    Console.WriteLine("Enter diseases :");
                    string[] diseases_name = Console.ReadLine().Split();
                    bool is_input_ok = true;
                    foreach (string des in diseases_name)
                    {
                        is_input_ok = is_disease_input_correct(des);
                        if (!is_input_ok)
                        {
                            break;
                        }
                    }
                    if (!is_input_ok)
                    {
                        Console.WriteLine("one or more input name are incorrect !");
                        warnings.Add($"while Examintaion of drug sensitivity in a prescription, wrong inputs were given!");
                        continue;
                    }
                    watch.Start();
                    List<Dis> disease_objects = new List<Dis>();
                    foreach (string disease_name in diseases_name)
                    {
                        Dis disease = dises.Search(disease_name);
                        if (disease == null)
                        {
                            Console.WriteLine("disease doesn't exist!");
                            warnings.Add($"while examintaion of drug sensitivity in a prescription, input disease {disease_name} doesn't exist!");
                        }
                        else
                        {
                            disease_objects.Add(disease);
                        }
                    }
                    Console.WriteLine("Enter drug name: ");
                    string drug_name = Console.ReadLine();
                    is_input_ok = is_drug_input_correct(drug_name);
                    if (!is_input_ok)
                    {
                        Console.WriteLine("wrong input !");
                        warnings.Add($"while Examintaion of drug sensitivity in a prescription, wrong inputs were given!");
                        continue;
                    }
                    Console.WriteLine();
                    Drug drug_object = drugs.Search(drug_name);
                    if (drug_object == null)
                    {
                        Console.WriteLine("drug doesn't exist!");
                        warnings.Add($"while examintaion of drug sensitivity in a prescription, input drug {drug_name} doesn't exist!");
                    }
                    else
                    {
                        foreach (Dis disease_object in disease_objects)
                        {
                            foreach (alergi al in disease_object.Alergies)
                            {
                                if (al.drug == drug_object)
                                {
                                    if (al.drug.is_deleted) { continue; }
                                    if (al.status == false)
                                    {
                                        Console.WriteLine($"{disease_object.Name} : ({al.drug.Name},-)");
                                    }
                                }
                            }

                        }
                    }
                }
                else if (request == 4)
                {
                    Console.WriteLine("NOT IMPLEMENTED!");
                }
                else if (request == 5)
                {
                    Console.WriteLine("1. Create Disease");
                    Console.WriteLine("2. Create Drug");
                state_5: Console.Write("YOUR REQUST : ");
                    int menu_create = int.Parse(Console.ReadLine());

                    if (menu_create == 1)
                    {
                        Console.Write("Please enter Name of disease : ");
                        watch.Start();
                        string Disease_Name = Console.ReadLine();
                        bool is_input_ok = is_disease_input_correct(Disease_Name);
                        if (!is_input_ok)
                        {
                            Console.WriteLine("input is not ok !");
                            warnings.Add($"while creating new Disease, input was incorrect (expected : e.x Dis_cpddwkmrzc but got {Disease_Name}).");
                            continue;
                        }
                        Dis dis_object = new Dis(Disease_Name);
                        dises.add(dis_object);
                    }
                    else if (menu_create == 2)
                    {
                        Console.Write("Please enter Name of the drug : ");
                        watch.Start();
                        string Drug_Name = Console.ReadLine();
                        bool is_input_ok = is_drug_input_correct(Drug_Name);
                        if (!is_input_ok)
                        {
                            Console.WriteLine("input is not ok !");
                            warnings.Add($"while creating new drug, input was incorrect (expected : e.x Drug_aznhdnutud  but got {Drug_Name}).");
                            continue;
                        }
                        Console.Write("Please enter price of the drug : ");
                        int Drug_price = int.Parse(Console.ReadLine());
                        Drug drug_object = new Drug(Drug_Name, Drug_price);
                        drugs.add(drug_object);
                        // first part of 8
                        Drug[] random_drugs = drugs.get_random_drug(1);
                        foreach (Drug random_drug in random_drugs)
                        {
                            drug_object.AddEfect(random_drug, "BAD_EFFECT");
                        }
                        // second part of 8
                        Dis[] random_diseases = dises.get_random_diseases(1);
                        foreach (Dis disease in random_diseases)
                        {

                            alergi alergi = new alergi(drug_object, random_boolean());
                            disease.add_alergies(alergi);
                        }
                    }
                    else
                    {
                        goto state_5;
                    }
                    Console.WriteLine();
                }
                else if (request == 6)
                {
                    Console.WriteLine("1. Delete Disease");
                    Console.WriteLine("2. Delete Drug");
                state_6: Console.Write("YOUR REQUST : ");
                    int menu_delete = int.Parse(Console.ReadLine());

                    if (menu_delete == 1)
                    {
                    state_a: Console.Write("Are you sure you want to remove a diseae ?(Y/N) ");
                        char accept_delete = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine();
                        if (accept_delete == 'Y')
                        {
                            Console.Write("Please enter name of disease you want to delete it ? ");
                            watch.Start();
                            string Delete_Name_Dis = Console.ReadLine();
                            bool is_input_ok = is_disease_input_correct(Delete_Name_Dis);
                            if (!is_input_ok)
                            {
                                Console.WriteLine("wrong input !");
                                warnings.Add($"while deleting a disease, wrong input format was given ({Delete_Name_Dis})");
                                continue;
                            }
                            Console.WriteLine();
                            bool delete_status = dises.remove(Delete_Name_Dis);
                            if (delete_status == false)
                            {
                                Console.WriteLine("deletation failed because the disease you wanted to delete dosen't exist !");
                                warnings.Add("deletation failed because the disease you wanted to delete dosen't exist !");
                            }
                            else
                            {
                                Console.WriteLine("delete was successful!");
                            }
                        }
                        else if (accept_delete == 'N')
                        {
                            goto state;
                        }
                        else
                        {
                            goto state_a;
                        }
                    }
                    else if (menu_delete == 2)
                    {
                    state_ad: Console.Write("Are you sure you want to remove a drug ?(Y/N) ");
                        char accept_delete = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine();
                        if (accept_delete == 'Y')
                        {
                            Console.Write("Please enter name of drug you want to delete it ? ");
                            string Delete_Name_Drug = Console.ReadLine();
                            watch.Start();
                            bool is_input_ok = is_drug_input_correct(Delete_Name_Drug);
                            if (!is_input_ok)
                            {
                                Console.WriteLine("wrong input !");
                                warnings.Add($"while deleting a drug, wrong input format was given ({Delete_Name_Drug})");
                                continue;
                            }
                            bool delete_status = drugs.remove(Delete_Name_Drug);
                            if (delete_status == false)
                            {
                                Console.WriteLine("deletation failed because the drug you wanted to delete dosen't exist !");
                                warnings.Add("deletation failed because the drug you wanted to delete dosen't exist !");
                            }
                            else
                            {
                                Console.WriteLine("delete was successful!");
                            }
                        }
                        else if (accept_delete == 'N')
                        {
                            goto state;
                        }
                        else
                        {
                            goto state_ad;
                        }
                    }
                    else
                    {
                        goto state_6;
                    }
                    Console.WriteLine();
                }
                else if (request == 7)
                {
                    Console.WriteLine("1. search Disease");
                    Console.WriteLine("2. search Drug");
                state_7: Console.Write("YOUR REQUST : ");
                    int menu_search = int.Parse(Console.ReadLine());

                    if (menu_search == 1)
                    {
                        Console.Write("Please enter the name of disease you want to search from dataset ? ");
                        string Search_Name_disease = Console.ReadLine();
                        watch.Start();
                        Console.WriteLine();
                        bool is_input_ok = is_disease_input_correct(Search_Name_disease);
                        if (!is_input_ok)
                        {
                            Console.WriteLine("Wrong input!");
                            warnings.Add($"while searching in diseases, wrong inputs were given {Search_Name_disease}");
                            continue;
                        }
                        Dis disease = dises.Search(Search_Name_disease);
                        if (disease == null)
                        {
                            Console.WriteLine("Not Found!");
                            warnings.Add($"disease {Search_Name_disease} not found on disease search");
                        }
                        else
                        {
                            Console.WriteLine("diease information :");
                            Console.WriteLine($"name : {disease.Name}");
                            Console.WriteLine("disease alergies:");
                            if (disease.Alergies == null)
                            {
                                Console.WriteLine("this disease has no alergies.");
                            }
                            else
                            {
                                foreach (alergi al in disease.Alergies)
                                {
                                    if (al.drug.is_deleted) { continue; }
                                    char pos = '+';
                                    if (al.status == true)
                                    {
                                        pos = '-';
                                    }
                                    Console.Write($"({al.drug.Name},{pos})");
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (menu_search == 2)
                    {
                        Console.Write("Please enter the name of drug you want to search from dataset ? ");
                        string Search_Name_Drug = Console.ReadLine();
                        watch.Start();
                        Console.WriteLine();
                        bool is_input_ok = is_drug_input_correct(Search_Name_Drug);
                        if (!is_input_ok)
                        {
                            Console.WriteLine("Wrong input!");
                            warnings.Add($"while searching in drugs, wrong inputs were given {Search_Name_Drug}");
                            continue;
                        }
                        Drug searched_drug = drugs.Search(Search_Name_Drug);
                        if (searched_drug == null)
                        {
                            Console.WriteLine("Not found!");
                            warnings.Add($"while searching in drugs, drug {Search_Name_Drug} not found !");
                        }
                        else
                        {
                            Console.WriteLine($"result : {searched_drug.Name} with price {searched_drug.Price}");
                        }
                    }
                    else
                    {
                        goto state_7;
                    }
                }
                else if (request == 8)
                {
                    watch.Start();
                    Console.WriteLine("warnings: ");
                    foreach (string warn in warnings)
                    {
                        Console.WriteLine($"** {warn}");
                    }
                }
                else if (request == 9)
                {
                    string path_d = @$"{path_to_datas}\drugs.txt";
                    string path_di = @$"{path_to_datas}\diseases.txt";
                    string path_aler = @$"{path_to_datas}\alergies.txt";
                    string path_eff = @$"{path_to_datas}\effects.txt";
                    int number = 0;
                    foreach (Drug nemone2 in drugs.table)
                    {
                        Drug nemone = nemone2;
                        while (nemone != null)
                        {
                            if (nemone != null)
                            {
                                string line = nemone.Name + " : " + nemone.Price + "\r\n";
                                if (number == 0)
                                {
                                    File.WriteAllText(path_d, line);
                                    number++;
                                }
                                else
                                {
                                    File.AppendAllText(path_d, line);
                                }
                            }
                            nemone = nemone.Colision;
                        }

                    }
                    int number1 = 0;
                    foreach (Dis nemone2 in dises.table)
                    {
                        Dis nemone = nemone2;
                        while (nemone != null)
                        {
                            if (nemone != null)
                            {
                                string line = nemone.Name + "\r\n";
                                if (number1 == 0)
                                {
                                    File.WriteAllText(path_di, line);
                                    number1++;
                                }
                                else
                                {
                                    File.AppendAllText(path_di, line);
                                }
                            }
                            nemone = nemone.Colision;
                        }

                    }
                    int number2 = 0;
                    foreach (Dis nemone3 in dises.table)
                    {
                        Dis nemone = nemone3;
                        while (nemone != null)
                        {
                            if (nemone != null)
                            {
                                int num3 = 0;
                                int num1 = 0;
                                string line = nemone.Name + " : ";
                                if (nemone.Alergies != null)
                                {
                                    num3++;
                                    foreach (alergi nemone2 in nemone.Alergies)
                                    {
                                        if (nemone2 != null)
                                        {
                                            if (num1 == 0)
                                            {
                                                line += "(" + nemone2.drug.Name + ",";
                                                if (nemone2.status)
                                                {
                                                    line += "+)";
                                                }
                                                else
                                                {
                                                    line += "-)";
                                                }
                                                num1++;
                                            }
                                            else
                                            {
                                                line += " ; (" + nemone2.drug.Name + ",";
                                                if (nemone2.status)
                                                {
                                                    line += "+)";
                                                }
                                                else
                                                {
                                                    line += "-)";
                                                }
                                            }
                                        }
                                    }
                                }

                                line += "\r\n";


                                if (num3 != 0)
                                {
                                    if (number2 == 0)
                                    {
                                        File.WriteAllText(path_aler, line);
                                        number2++;
                                    }
                                    else
                                    {
                                        File.AppendAllText(path_aler, line);
                                    }
                                }

                            }
                            nemone = nemone.Colision;
                        }

                    }
                    int number4 = 0;
                    foreach (Drug nemone in drugs.table)
                    {

                        Drug nemone2 = nemone;
                        while (nemone2 != null)
                        {
                            int num = 0;
                            if (nemone2.effects != null)
                            {
                                string line = nemone2.Name + " : ";
                                foreach (effect eff in nemone2.effects)
                                {
                                    if (eff != null)
                                    {
                                        if (num == 0)
                                        {
                                            line += "(" + eff.drug.Name + "," + eff.effects + ")";
                                            num++;
                                        }
                                        else
                                        {
                                            line += " ; (" + eff.drug.Name + "," + eff.effects + ")";
                                        }
                                    }
                                }
                                line += "\r\n";
                                if (number4 == 0)
                                {
                                    File.WriteAllText(path_eff, line);
                                    number4++;
                                }
                                else
                                {
                                    File.AppendAllText(path_eff, line);
                                }
                            }
                            nemone2 = nemone2.Colision;
                        }
                    }

                    //string createText =  ;

                    //Console.WriteLine("amir mohammad");

                }
                else if (request == 10)
                {
                    Console.Write("Please enter the name of disease : ");
                    string Search_Name_disease = Console.ReadLine();
                    watch.Start();
                    Console.WriteLine();
                    bool is_input_ok = is_disease_input_correct(Search_Name_disease);
                    if (!is_input_ok)
                    {
                        Console.WriteLine("Wrong input!");
                        warnings.Add($"while showing a disease alergies, wrong inputs were given {Search_Name_disease}");
                        continue;
                    }
                    Dis disease = dises.Search(Search_Name_disease);
                    if (disease == null)
                    {
                        Console.WriteLine("this disease doesn't exist !");
                        warnings.Add($"while showing a disease alergies, unavailabe disease was searched {Search_Name_disease}");
                    }
                    else
                    {
                        if (disease.Alergies == null)
                        {
                            Console.WriteLine("there is no alergy for this disease !");
                            continue;
                        }
                        foreach (alergi al in disease.Alergies)
                        {
                            if (al.drug.is_deleted) { continue; }
                            char sign = '+';
                            if (al.status == false)
                            {
                                sign = '-';
                            }
                            Console.Write($" ({al.drug.Name},{sign}) ;");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("OUT OF MENU REQUEST !");
                    warnings.Add("out of menu request! (this is forbidden)");
                }
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds * 1000} micro second");
                watch.Reset();
            }
        }
    }
}
