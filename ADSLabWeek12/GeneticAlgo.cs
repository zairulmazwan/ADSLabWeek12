using System.Data;

public class GeneticAlgo
{
    public void runGA(int generations, List<double> data)
    {
        //Create initial population
        
        //Sort the population based on their fitness values
       

        //For results
        //A 2D array of size generatons (row), col-0:generation, col-1:p1, col-2:p2, col-3:c1, col-4:c2, col-5:mutant
        //Create a list of list to store the best chromosome for each generation

        //We are going to use this crossover strategy. The crossover prob. is reducing by generation
        double crossOverProb = 0.9;
        double coRate = 0.9/generations;

        //Loop until number of generation
        for(int i=0; i<generations; i++)
        {
            Console.WriteLine("Generation "+i);
           
            //Write values to results for generation number, fitness for parents, and the solutions (the chromosome)

            //Produce 2 children using the crossOver method. The method will return a list of Individuals

            //Produce a mutant. Create an Individual from the best parent, the mutate their genes. Use copyIndividual and mutation for this operation.

            //Add the new candidates to the population, i.e., child 1, child 2, and mutant. Use addCandidates method.
        
            //Sort the population after the new candidates join the population

            //Reduce the crossover probability
            crossOverProb -= coRate;

            
        }

        //Write results to csv files: writeFitnessResults, writeSolutions, writePopulation

    }
}
public class Individual
{
    public List<int> chromosome;
    public double fitness;
    public List<Double> data = new List<double>();

    public Individual(List<Double> dataset)
    {
        Random r = new Random();
        data = dataset;
        chromosome = new List<int>();
        for (int i=0; i<dataset.Count; i++)
        {
            int gene = r.Next(1,9999)%2;
            chromosome.Add(gene);
        }
        calCurrentFit();
    }

    public void calCurrentFit()
    {
        fitness = 0;
        double left=0, right=0;
        for(int i=0; i<chromosome.Count; i++)
        {
            if(chromosome[i]==0){
                left+=data[i];
                // Console.WriteLine("Left "+currenSol[i]);
            }else{
                right+=data[i];
                // Console.WriteLine("Right "+currenSol[i]);
            }
        }
        fitness = Math.Round(Math.Abs(left-right),2);
    }

    public double getFitness()
    {
        calCurrentFit();
        return fitness;
    }

    //This method is to avoid from the object gets the reference.
    public Individual copyIndividual()
    {
        Individual other = (Individual)this.MemberwiseClone();  
        other.chromosome = new (chromosome);  
        other.fitness = fitness;  
        return other;  
    }

    public void mutation (double prob)
    {
        Random r = new Random();
       
        if (prob>1.0)
        {
            Console.WriteLine("Probability should be between 0 and 1");
            return;
        }
        else
        {
            //Complete this section!
        }
        calCurrentFit();
    }

    public void printIndividual()
    {
        for (int i=0; i<chromosome.Count; i++)
        {
            Console.Write(chromosome[i]);
            if (i<chromosome.Count-1)
                Console.Write(",");
        }
        Console.WriteLine("  "+fitness);
    }
}

public class Population
{
    public List<Individual> pop = new List<Individual>();

    public Population(int n, List<double> data)
    {
        for(int i=0; i<n; i++)
        {
            Individual ind = new Individual(data);
            pop.Add(ind);
        }
        sortPopulation();
    }


    public List<Individual> getParents ()
    {
        List<Individual> parents = new List<Individual>();
        for (int i=0; i<2; i++)
        {
            parents.Add(pop[i]); //We pick the first 2 individual from pop
        }
        return parents;
    }

    public void printParents()
    {
        for (int i=0; i<2; i++)
        {
            pop[i].printIndividual();  //We pick the first 2 individual from pop
        }
    }
    public void addCandidates(Individual c1, Individual c2, Individual mutant)
    {
        pop.Add(c1);
        pop.Add(c2);
        pop.Add(mutant);
    }

    public void sortPopulation()
    {
        List<Individual> res = pop.OrderBy(o=>o.fitness).ToList();
        pop = res.ToList();
    }

    public Individual getBestIndividual()
    {
        Individual best = pop[0];
        return best;
    }

    public List<Individual> crossOver (double coProb)
    {
        Individual newCandidates1 = pop[0].copyIndividual(); //getting the genes from parent 1
        Individual newCandidates2 = pop[1].copyIndividual(); //getting the genes from parent 2
        List<Individual> res = new List<Individual>(); //We need this to store 2 children (of class Individual)

        //Complete this method based on Algorithm 2: One Point Crossover


        return res; //There are 2 individuals in this variable
    }

    public void printPopulation()
    {
        for (int i=0; i<pop.Count; i++)
        {
            pop[i].printIndividual();
        }
    }

}

//©ZairulMazwan©