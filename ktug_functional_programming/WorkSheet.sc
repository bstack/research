package greeter

object WorkSheet {
  println("Welcome to the Scala worksheet")       //> Welcome to the Scala worksheet
  
  val x = 8                                       //> x  : Int = 8

	var y = 5                                 //> y  : Int = 5
	y = 6
	
	
	
	
	
	
	
	
  def increase(i: Int) = i + 1                    //> increase: (i: Int)Int
  increase(x)                                     //> res0: Int = 9
  increase(x)                                     //> res1: Int = 9
  
  // lazy examples
  //val a = b + 1; val b = 1;
  //lazy val a = b + 1; lazy val b = 1;
  //println(a)
  //println(b)
  
  
 
}