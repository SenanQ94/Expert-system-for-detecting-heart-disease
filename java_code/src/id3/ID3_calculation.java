


import java.util.ArrayList;
import java.util.List;
import java.util.Vector;
import java.text.DecimalFormat;
import java.util.HashMap;

public class ID3_calculation {
    
    HashMap<String,Double > information_gain = new HashMap<String,Double>();
    HashMap<String,String > gain_per_subattribute = new HashMap<String,String>();
    Vector attributes = new Vector();
    Vector classification = new Vector();
    List<Node> node = new ArrayList<>();
    
    double morethan_onezero = 0.009;
    
    //H(S)
    double entropy =0;
    
    List< List<String> > list_of_attributes = new ArrayList();
    String [][] table ;
    String[] newValue;

    public ID3_calculation(String[][] table) {
        this.table = table;
    }
    public ID3_calculation(String[] newValue){this.newValue=newValue;}
    
    public List<Node> getNode(){
      return node;
    }
    
    public Vector getlistofAttributes(){
      return attributes;
    }
    
    public HashMap<String,Double> getInformationGain(){
      
        return information_gain;
      
    } 
    
    
     public  HashMap<String,String > getInformationGain_of_subAttribute(){
      
        return gain_per_subattribute;
      
    } 
    
    
    public void calculate_attribute(){
    
        
            for(int j = 0 ; j < table[0].length-1; j++){
        
                 if(!attributes.contains(table[0][j])){
                   attributes.addElement(table[0][j]);
                 }
                 
             }
            
     
        
        
    }
    
    public void calculate_class(){
        for(int i = 1 ; i < table.length; i++){       
             for(int j = (table[i].length-1) ; j < table[i].length; j++){     
                 if(!classification.contains(table[i][j])){
                   classification.addElement(table[i][j]);                      
                 }}}}
    
    public void calculate_entropy(){     
        List<Integer> total_classification_num = new ArrayList<>();
        double total_entropy=0;
        double total_rows  = table.length - 1;
        int count =0;  
        for(int z = 0 ; z < classification.size(); z++){
             for(int i = 1 ; i < table.length; i++){
                if(classification.get(z).toString().equals(table[i][ (table[i].length - 1) ] )){
                 count++;
                }   
             }
             total_classification_num.add(count);
             count=0;
        }
      for(int z = 0 ; z <  total_classification_num.size(); z++){
           double ps =  total_classification_num.get(z);
           double cls_entropy = -1* ( (ps/total_rows) * log(ps/total_rows,2) ) ;
           entropy = entropy + cls_entropy;
      } 
      DecimalFormat df2 = new DecimalFormat(".##");
      String change = df2.format(entropy);
      if(change.contains(",")) {
    	  change = change.replace(",", ".");
      } 
      entropy = Double.parseDouble(change);
      System.out.println( "\nH( S ) = " + entropy+"\n");
    }
    
    public void information_gain(){ 
        HashMap<String,Integer> frequency ;
        HashMap<String,List<String> > frequency_index ;
        HashMap<String,List<classification> > classifies ;
        List<HashMap<String,List<classification> > > listofclassifies = new ArrayList();  
        List<HashMap<String,Integer>> listoffrequency  = new ArrayList();    
        List<HashMap<String,List<String> >> listoffrequency_index  = new ArrayList();
        for(int i = 0 ; i < attributes.size(); i++ ){
            classifies = new  HashMap<String,List<classification> >();
            frequency = new HashMap<String,Integer>();
            for(int j = 1 ; j < table.length; j++ ){            
                if(! frequency.containsKey(table[j][i]) ){
                 frequency.put(table[j][i], 0);
               }           
                if(classifies.containsKey(table[j][i]) ){                    
                    List<classification> temp = classifies.get(table[j][i]);
                        int flag =0;                       
                        for(int z =0 ; z < temp.size(); z++  ){                        
                            if(temp.get(z).getClassification_attributes().equals(table[j][table[j].length-1])){                                
                                 String sub_attri = temp.get(z).getClassification_attributes();
                                 int sub_attri_rep = temp.get(z).getRepetition();
                                 flag =1;
                                 sub_attri_rep++;
                                 temp.remove(z);
                                 temp.add(new classification( sub_attri,sub_attri_rep) );
                                 classifies.put(table[j][i],  temp );
                                 break;
                            }}                       
                        if(flag == 0){                       
                        temp.add(new classification( table[j][table[j].length-1] ,1));
                        classifies.put(table[j][i],  temp );                       
                        }} 
                else{               
                    List<classification> temp = classifies.get(table[j][i]);                   
                    if(temp == null){
                        temp = new ArrayList<>();
                        temp.add(new classification( table[j][table[j].length-1] ,1));
                        classifies.put(table[j][i],  temp );                     
                    }}}           
            listofclassifies.add(classifies);
            listoffrequency.add(frequency);
        }
        for(int i = 0 ; i < attributes.size(); i++ ){        
            List<String> attri = new ArrayList<>();
            frequency_index = new HashMap<String,List<String>>();
            for(int j = 1 ; j < table.length; j++ ){
                if(!attri.contains(table[j][i])){
                  attri.add(table[j][i]);
                }               
                if( listoffrequency.get(i).containsKey(table[j][i]) ){           
                 int count = listoffrequency.get(i).get(table[j][i]);
                 count++;
                 listoffrequency.get(i).put(table[j][i], count );
                 List<String> index = frequency_index.get(table[j][i]);
                 if(index==null){
                     index = new ArrayList<>();
                     index.add(table[j][ table[j].length-1 ]);
                     frequency_index.put(table[j][i], index);                  
                 }
                 else{
                     index.add(table[j][ table[j].length-1 ]);
                     frequency_index.put(table[j][i], index);                    
                 }}}
            listoffrequency_index.add(frequency_index);
            node.add( new Node(attributes.get(i).toString() , attri , listoffrequency.get(i) ,listoffrequency_index.get(i) ,listofclassifies.get(i) ) ); 
        }
        for(int i = 0 ; i < node.size(); i++ ){
            for(int j = 0 ; j < node.get(i).getListofattribute().size(); j++ ){
            }
        }
         for(int i = 0 ; i < attributes.size(); i++ ){
            for(int j = 0 ; j < node.size(); j++ ){
                if(attributes.get(i).equals(node.get(j).getAttribute() )){                
                  double average_entro = 0;
                  double total_rows = table.length-1;
                  List<String> parts = node.get(j).getListofattribute();
                  double [] sub1 = new double[parts.size()];
                  double [] sub2 = new double[parts.size()];
                  double sum =0;
                   List<String> addd = new ArrayList<>();
                  for(int z = 0 ; z < parts.size(); z++){                  
                      double sub_total_attribute = node.get(j).getFrequency().get(parts.get(z)); 
                      double sum2 =0;                      
                     List<classification> ty =  node.get(j).getClassifies().get(parts.get(z));
                     int cc = ty.get(0).getRepetition();
                     String str = ty.get(0).getClassification_attributes();
                     for(int q = 0 ; q < ty.size(); q++){                        
                         if(q >= 1 ){
                          if(cc == ty.get(q).getRepetition()){
                             if(addd.contains(ty.get(q).getClassification_attributes())){                          
                                 for(int k =0 ; k < ty.size() ; k++){                                 
                                  if(addd.contains(ty.get(k).getClassification_attributes())){                                 
                                  }}}
                             else{
                                  cc = ty.get(q).getRepetition();
                                  str = ty.get(q).getClassification_attributes();
                                  addd.add(str);   
                             }}                        
                         else if(cc < ty.get(q).getRepetition()){                        
                             cc = ty.get(q).getRepetition();
                             str = ty.get(q).getClassification_attributes();
                             addd.add(str);                          
                         }}
                         double nu = ty.get(q).getRepetition();
                         sum2 = sum2 + ( -1 * (  nu /sub_total_attribute * log( nu /sub_total_attribute  , 2   ) ));
                     }
                     sub1[z] =sum2;
                     sub2[z] = sub_total_attribute / total_rows;
                     gain_per_subattribute.put(parts.get(z), str);
                     sum2=0; 
                  }               
                  for(int z = 0 ; z < parts.size(); z++){
                    sum = sum + (sub1[z] * sub2[z]) ;
                    if((sub1[z] * sub2[z]) == 0 ){
                          gain_per_subattribute.put(parts.get(z)+"1", gain_per_subattribute.get(parts.get(z)) );
                          gain_per_subattribute.put(parts.get(z), "0" );
                    }}
                  DecimalFormat df2 = new DecimalFormat(".###");
                  String change = df2.format(sum);
                  if(change.contains(",")) {
                	  change = change.replace(",", ".");
                  }  
                  sum = Double.parseDouble(change);
                 double gain = entropy - sum;
                 DecimalFormat df3 = new DecimalFormat(".####");
                 change = df3.format(gain);
                 if(change.contains(",")) {
               	  change = change.replace(",", ".");
                 }        
                 gain = Double.parseDouble(change);
                 if(gain == 0.0){
                   gain = morethan_onezero;
                   morethan_onezero = morethan_onezero - 0.001;
                 }      
                 information_gain.put(attributes.get(i).toString(), gain);
                 System.out.println(attributes.get(i).toString()+ " = "+  gain);        
                }}}}
    
    
    static double log(double x, int base)
{
    return (double) (Math.log(x) / Math.log(base));
}
    
}
