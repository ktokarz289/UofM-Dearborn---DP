import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.List;


public class singletonMoonFactory {

	//This is the general abstract factory for moon generations
	interface abstractMoonFactory{
		
		//public abstractMoon createMoon( );
		public abstractMoon createMoon();
	};
	//The concrete moons listed below are my concrete factory that implement the singleton factory per the instructions
	 public static class concreteMoon implements abstractMoonFactory{
		private static moon myMoon;
		private static abstractMoonFactory factory;

		private concreteMoon() {
			// TODO Auto-generated method stub
		};
		
		public static abstractMoonFactory concreteSingleton(){
			if (factory == null)
			{
				factory = new concreteMoon();
			};
			return factory;
		}

		@Override
		public abstractMoon createMoon() {
			if (myMoon == null)
			{
				myMoon = new moon();
			};
			return myMoon;
		}		
	}
	
	public static class concreteSuperMoon implements abstractMoonFactory{
		private static superMoon myMoon;
		private static abstractMoonFactory factory;
		private concreteSuperMoon() {
			// TODO Auto-generated method stub
		}
		
		public static abstractMoonFactory concreteSingleton(){
			if (factory == null)
			{
				factory = new concreteSuperMoon();
			};
			
			return factory;
		}

		@Override
		public abstractMoon createMoon() {
			// TODO Auto-generated method stub
			if (myMoon == null)
			{
				myMoon = new superMoon();
			};
			return myMoon;
		};
	}
	
	public static class concreteAdvancedMoon implements abstractMoonFactory{
		private static advancedMoon myMoon;
		private static abstractMoonFactory factory;
		private concreteAdvancedMoon() {
			// TODO Auto-generated method stub
		}

		public static abstractMoonFactory concreteSingleton(){
			if (factory == null)
			{
				factory = new concreteAdvancedMoon();
			};
			return factory;
		}

		@Override
		public abstractMoon createMoon() {
			// TODO Auto-generated method stub
			if (myMoon == null)
			{
				myMoon = new advancedMoon();
			};
			return myMoon;
		};
	}
	
	public static class concreteUltraMoon implements abstractMoonFactory{
		private static ultraMoon myMoon;
		private static abstractMoonFactory factory;
		private concreteUltraMoon() {
			// TODO Auto-generated method stub
		}

		public static abstractMoonFactory concreteSingleton(){
			if (factory == null)
			{
				factory = new concreteUltraMoon();
			};
			return factory;
		}

		@Override
		public abstractMoon createMoon() {
			// TODO Auto-generated method stub
			if (myMoon == null)
			{
				myMoon = new ultraMoon();
			};
			return myMoon;
		};
		
	}
	
	//Below is the abstract product class
	interface abstractMoon{
		public abstract void displayCPU();
		public abstract void displayMMU();
		public abstract void displayMB();
	};
	
	// Classes below are the concrete products classes
	public static class moon implements abstractMoon{

		@Override
		public void displayCPU() {
			// TODO Auto-generated method stub
			System.out.print("Moon CPU, ");
		}

		@Override
		public void displayMMU() {
			// TODO Auto-generated method stub
			System.out.print("Moon MMU, ");
		}

		@Override
		public void displayMB() {
			// TODO Auto-generated method stub
			System.out.print("Moon Motherboard");
		};
		
	}
	public static class superMoon implements abstractMoon{

		@Override
		public void displayCPU() {
			// TODO Auto-generated method stub
			System.out.print("Super Moon CPU, ");
		}

		@Override
		public void displayMMU() {
			// TODO Auto-generated method stub
			System.out.print("Super Moon MMU, ");
		}

		@Override
		public void displayMB() {
			// TODO Auto-generated method stub
			System.out.print("Super Moon Motherboard");
		};
	}
	public static class advancedMoon implements abstractMoon{
		@Override
		public void displayCPU() {
			// TODO Auto-generated method stub
			System.out.print("Advanced Moon CPU ,");
		}

		@Override
		public void displayMMU() {
			// TODO Auto-generated method stub
			System.out.print("Advanced Moon MMU ,");
		}

		@Override
		public void displayMB() {
			// TODO Auto-generated method stub
			System.out.print("Advanced Moon Motherboard");
		};
		
	}
	public static class ultraMoon implements abstractMoon{
		@Override
		public void displayCPU() {
			// TODO Auto-generated method stub
			System.out.print("Ultra Moon CPU, ");
		}

		@Override
		public void displayMMU() {
			// TODO Auto-generated method stub
			System.out.print("Ultra Moon MMU, ");
		}

		@Override
		public void displayMB() {
			// TODO Auto-generated method stub
			System.out.print("Ultra Moon Motherboard");
		};
	}
	//This is the client that builds everything 
	public class client{
		public abstractMoon currentMoon;
		
		public client( abstractMoonFactory factory ){
			abstractMoon currentMoon = factory.createMoon();
			currentMoon.displayCPU();
			currentMoon.displayMMU();
			currentMoon.displayMB();
			System.out.print("\n");
		};
	}
	
	public static void main(String[] args){
		
		singletonMoonFactory s = new singletonMoonFactory();
		String line;
		File testFile = new File("C:\\Users\\kristopher.tokarz\\Desktop\\moonAssignment.txt");
		try {
		      BufferedReader input =  new BufferedReader(new FileReader(testFile));
		      try {
		        line = null; 
		        while (( line = input.readLine()) != null){
		        	if (line.equals("Moon"))
		        	{
		        		
		        		abstractMoonFactory m = concreteMoon.concreteSingleton();
		        		client c1 = s.new client(m);
		         	}
		        	else if (line.equals("Advanced Moon"))
		        	{
		        		abstractMoonFactory m = concreteAdvancedMoon.concreteSingleton();
		        		client c1 = s.new client(m);
		        	}
		        	else if (line.equals("Super Moon"))
		        	{
		        		abstractMoonFactory m = concreteSuperMoon.concreteSingleton();
		        		client c1 = s.new client(m);
		        	}
		        	else if (line.equals("Ultra Moon"))
		        	{
		        		abstractMoonFactory m = concreteUltraMoon.concreteSingleton();
		        		client c1 = s.new client(m);
		        	}
		        }
		      }
		      finally {
		        input.close();
		      }
		    }
		    catch (IOException ex){
		      ex.printStackTrace();
		    }
	};
}
