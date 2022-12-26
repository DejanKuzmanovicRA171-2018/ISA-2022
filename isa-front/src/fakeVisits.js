const visits = [
    {
      _id: "1b21ca3eeb7f6fbccd471815",
      center: "A",
      date: "12/2/2023",
      price: "1500",
      duration: "30",
      
    },
    {
      _id: "221ca3eeb7f6fbccd471816",
      center: "A",
      date: "11/5/2023",
      price: "2000",
      duration: "45",
  
    },
    {
      _id: "3b21ca3eeb7f6fbccd471817",
      center: "A",
      date: "11/5/2022",
      price: "1500",
      duration: "20",
    },
    {
      _id: "4b21ca3eeb7f6fbccd471855",
      center: "D",
      date: "8/8/2023",
      price: "1700",
      duration: "25",
    },
    {
      _id: "5b21ca3eeb7f6fbccd471887",
      center: "E",
      date: "1/13/2023",
      price: "2500",
      duration: "20",
    },
    {
      _id: "6b21ca3eeb7f6fbccd471800",
      center: "F",
      date: "2/2/2023",
      price: "2500",
      duration: "15",
    },
    {
      _id: "7b21ca3eeb7f6fbccd471822",
      center: "G",
      date: "8/2/2023",
      price: "3000",
      duration: "15",
    },
  ];
  
  export function getVisits() {
    return visits;
  }
  
  export function getVisit(id) {
    return visits.find(v => v._id === id);
  }
  
  export function saveVisit(visit) {
    let visitInDb = visits.find(v => v._id === visit._id) || {};
    visitInDb.date = visit.date;
    visitInDb.price = visit.price;
    visitInDb.duration = visit.duration;
  
    if (!visitInDb._id) {
      visitInDb._id = Date.now().toString();
      visits.push(visitInDb);
    }
  
    return visitInDb;
  }
  
  export function deleteVisit(id) {
    let visitInDb = visits.find(v => v._id === id);
    visits.splice(visits.indexOf(visitInDb), 1);
    return visitInDb;
  }