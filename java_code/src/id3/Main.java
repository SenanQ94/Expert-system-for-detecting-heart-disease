/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.PrintStream;
import java.util.HashMap;
import java.util.List;
import java.util.Scanner;
import java.util.Vector;

public class Main {
   
        static Scanner in = new Scanner(System.in);
        static String[][] table = null;
        static String[] newValue={""};
        public static void main(String[] args) throws FileNotFoundException
        {
            //write output to txt file
            PrintStream fileStream = new PrintStream("output.txt");
            System.setOut(fileStream);
            menu(); // read csv file and convert it to array
            ID3_calculation obj = new ID3_calculation(table);
            obj.calculate_class(); // number of target classes "positive & negative"
            obj.calculate_attribute(); // number of columns "attributes" in data set
            obj.calculate_entropy(); // calculate entropy for all nodes
            obj.information_gain(); // calculate gain
            List<Node> node = obj.getNode(); // list of nodes in tree
            HashMap<String, Double> information_gain = obj.getInformationGain(); // store gains of parent nodes into hashmap
            HashMap<String, String> information_gain_subAttribute = obj.getInformationGain_of_subAttribute();// store gains of child nodes into hashmap
            Vector attributes = obj.getlistofAttributes(); // store nodes in vector
            GenerateTree tree = new GenerateTree(attributes, node, information_gain, information_gain_subAttribute); // calculate  tree
            tree.create_tree(); // generate tree
            tree.Display_attribute(); 
            tree.display_tree();
        }
    public static void menu() {
                readFile("HeartDisease.csv"); // import csv file and convert is to array
                change_numeric_to_name(); // splite numric values into sets
    }
    public static void change_numeric_to_name() {
            // here we splite age, blood pressure, heart rate to 2 fields
            // based on average of numric values
            for (int j = 1; j < table.length; j++) {
                if (Double.parseDouble(table[j][0]) >= 48) {
                    table[j][0] = ">=48";
                } else if (Double.parseDouble(table[j][0]) < 48) {
                    table[j][0] = "<48";
                }

                if (Double.parseDouble(table[j][2]) >= 133) {
                    table[j][2] = ">=133";
                } else if (Double.parseDouble(table[j][2]) < 133) {
                    table[j][2] = "<133";
                }
                if (Double.parseDouble(table[j][5]) >= 138) {
                    table[j][5] = ">=138";
                } else if (Double.parseDouble(table[j][5]) < 138) {
                    table[j][5] = "<138";
                }}}
    public static void readFile(String filename) {
        // read csv file
        String csvFile = filename;
        BufferedReader br = null;
        BufferedReader pre_count = null;
        String line = "";
        String cvsSplitBy = ",";
        int row = 0;
        int col = 0;
        // convert csv to array
        try {
            pre_count = new BufferedReader(new FileReader(csvFile));
            pre_count = new BufferedReader(new FileReader(csvFile));
            while ((line = pre_count.readLine()) != null) {
                String[] attributes = line.split(cvsSplitBy);
                col = attributes.length - 1;
                row++;
            }
            table = new String[row][col];
            int rows = 0;
            br = new BufferedReader(new FileReader(csvFile));
            while ((line = br.readLine()) != null) {
                String[] attributes = line.split(cvsSplitBy);
                for (int i = 1; i < col + 1; i++) {
                    table[rows][i - 1] = attributes[i];
                }
                rows++;
            }
        } catch (IOException e) {
            System.out.println("File not found Exception");
        } finally {
            if (br != null) {
                try {
                    br.close();
                } catch (IOException e) {
                    System.out.println("File not found Exception Finally");
                }}}
}
}


 
